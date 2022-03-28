using System.Globalization;
using TMPro;
using UnityEngine;

namespace CarterGames.Assets.LeaderboardManager
{
    [HelpURL("https://carter.games/leaderboardmanager/leaderboarddisplay")]
    [AddComponentMenu("Carter Games/Leaderboard Manager/Leaderboard Display (TextMeshPro)")]
    public class LeaderboardDisplayTMP : LeaderboardDisplay
    {
        protected override void UpdateDataOnRows(LeaderboardEntry[] _data, int numberToShow)
        {
            var _rowCount = boardParent.transform.childCount;

            foreach (var row in cachedRows)
                row.SetActive(false);
            
            cachedRows.Clear();

            for (var i = startAt; i < numberToShow + startAt; i++)
            {
                if (_data.Length + startAt <= i) return;

                GameObject _obj;
                TMP_Text[] _text;

                if (i + startAt >= _rowCount + startAt)
                {
                    _obj = Instantiate(rowPrefab, boardParent);
                    _obj.name = "Leaderboard Display Row (TMP)";
                    cachedRows.Add(_obj);
                    _text = _obj.GetComponentsInChildren<TMP_Text>(true);
                }
                else
                {
                    _obj = boardParent.transform.GetChild(i).gameObject;
                    _obj.name = "Leaderboard Display Row (TMP)";
                    cachedRows.Add(_obj);
                    _text = _obj.GetComponentsInChildren<TMP_Text>(true);
                }

                if (!_obj.activeInHierarchy)
                    _obj.SetActive(true);

                _text[positionIndex].text = $"{positionPrefix}{i}{positionSuffix}";
                _text[nameIndex].text = _data[i - startAt].Name;
                
                _text[scoreIndex].text = formatScoreAsTime
                    ? GetScoreTimeFormatted(_data[i - startAt].Score)
                    : _data[i - startAt].Score.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}