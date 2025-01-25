using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class SPEAKERDATA
{
    public string name, castName;
    public string displayName => (castName != string.Empty ? castName : name);
    public bool isMC;
    public List<(int layer, string expression)> CastExpressions { get; set; }

    private const string NAMECAST_ID = " as ";
    private const string NPCCAST_ID = " npc ";
    private const string EXPRESSIONCAST_ID = " [";
    private const char EXPRESSIONLAYER_JOINER = ',';
    private const char EXPRESSIONLAYER_DELEIMITER = ':';
    public SPEAKERDATA(string rawSpeaker)
    {
        string pattern = @$"{NAMECAST_ID}|{NPCCAST_ID}|{EXPRESSIONCAST_ID.Insert(EXPRESSIONCAST_ID.Length-1, @"\")}";
        MatchCollection matches = Regex.Matches(rawSpeaker, pattern);

        castName = "";
        isMC = true;
        CastExpressions = new List<(int layer, string expression)>();

        if (matches.Count == 0)
        {
            name = rawSpeaker;
            return;
        }

        int index = matches[0].Index;

        name = rawSpeaker.Substring(0, index);

        for(int i = 0; i < matches.Count ; i++){
            Match match = matches[i];
            int startIndex = 0, endIndex = 0;
            if(match.Value == NAMECAST_ID){
                startIndex = match.Index + NAMECAST_ID.Length;
                endIndex = (i < matches.Count - 1) ? matches[i+1].Index : rawSpeaker.Length;
                castName = rawSpeaker.Substring(startIndex,endIndex-startIndex);
            }else if(match.Value == NPCCAST_ID){
                startIndex = match.Index + NPCCAST_ID.Length;
                endIndex = (i < matches.Count - 1) ? matches[i+1].Index : rawSpeaker.Length;
                isMC = false;
            }else if(match.Value == EXPRESSIONCAST_ID){
                startIndex = match.Index + EXPRESSIONCAST_ID.Length;
                endIndex = (i < matches.Count - 1) ? matches[i+1].Index : rawSpeaker.Length;
                string castExp = rawSpeaker.Substring(startIndex,endIndex-startIndex);

                CastExpressions = castExp.Split(EXPRESSIONLAYER_JOINER).Select(x => {
                   var parts = x.Trim().Split(EXPRESSIONLAYER_DELEIMITER);
                   return (int.Parse(parts[0]), parts[1]); 
                }).ToList();
            }
        }
    }
}
