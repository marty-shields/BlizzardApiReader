﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BlizzardApiReader.Core;
using BlizzardApiReader.Core.Enums;
using BlizzardApiReader.Diablo;
using BlizzardApiReader.Diablo.Models;
using BlizzardApiReader.WorldOfWarcraft;
using BlizzardApiReader.WorldOfWarcraft.Models;
using BlizzardApiReader.Starcraft2;
using BlizzardApiReader.Starcraft2.Models;

namespace BlizzardApiReader.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use your info here
            string clientId = "725104f779ad4300a44222e3a5c06093";
            string secret = "fxWYI9Xa6SlSZVySQONjCqLxnO8Bf5OI";
            int sc2ID = 8323934;
            string bt = "oisinmcl#2126";

            ApiConfiguration.Create()
                              .SetClientId(clientId)
                              .SetClientSecret(secret)
                              .SetRegion(Region.Europe)
                              .SetLocale(Locale.BritishEnglish)
                              .DeclareAsDefault();

            //For Diablo API
            var d3api = new DiabloApi();

            //For World of Warcraft API
            var wowApi = new WorldOfWarcraftApi();

            //For Starcraft 2 API
            var sc2Api = new Starcraft2Api();

            Task.Run(async () =>
            {
                //Using Diablo API
                //Get first Act information
                StoryAct act1 = await d3api.GetActAsync(1);
                Console.WriteLine($"act 1 name: {act1.Name}");

                //Using World of Warcraft API
                //Get list of bosses
                //List<Boss> bosses = wowApi.GetBossesAsync().Result;
                //foreach (Boss boss in bosses)
                //{
                //    Console.WriteLine($"Encounter: {boss.Name}") Description: {boss.Description}");
                //}

                //Using Starcraft 2 API
                //Player player = await sc2Api.GetPlayerAsync(8323934);
                //Console.WriteLine($"League ID: {player.Key.league_id} Season ID: {player.Key.season_id}");


                //Starcraft2.Models.Season season = await sc2Api.GetSeasonAsync(2);
                //Console.WriteLine($"Season ID: {season.SeasonID}, Number: {season.Number}, Year: {season.Year}, Start Date: {season.StartDate}, End Date: {season.EndDate}");

                //List<GrandmasterLeaderboard> GMLeaderboard = await sc2Api.GetGrandmasterLeaderboardAsync(2);
                //foreach (GrandmasterLeaderboard GM in GMLeaderboard)
                //{
                //    Console.WriteLine($"Members Count: {GM.TeamMembers.Count}, Previous Rank: {GM.PreviousRank}, Points: {GM.Points}, " +
                //                        $"Wins: {GM.Wins}, Losses: {GM.Losses}, MMR: {GM.MMR}, JoinTimestamp: {GM.JoinTimestamp}");
                //}


                Profile profile = await sc2Api.GetProfileAsync(2, 1, sc2ID);
                //Console.WriteLine($"Profile ID: {profile.Summary.ID}, RealmID: {profile.Summary.RealmID}, DisplayName: {profile.Summary.DisplayName}, Portrait: {profile.Summary.Portrait}, " +
                //                    $"DecalTerran: {profile.Summary.DecalTerran}, DecalProtoss: {profile.Summary.DecalProtoss}, DecalZerg: {profile.Summary.DecalZerg}, " +
                //                    $"TotalSwarmLevel: {profile.Summary.TotalSwarmLevel}, TotalAchievementPoints: {profile.Summary.TotalAchievementPoints}");

                //Console.WriteLine($"1v1: {profile.Snapshot.SeasonSnapshot.OnevOne.TotalGames}, 2v2: {profile.Snapshot.SeasonSnapshot.TwovTwo.TotalGames}, 1v1: {profile.Snapshot.SeasonSnapshot.ThreevThree.TotalGames}, 1v1: {profile.Snapshot.SeasonSnapshot.FourvFour.TotalGames}," +
                //                     $", Archon: {profile.Snapshot.SeasonSnapshot.Archon.TotalGames}, TotalRankedSeasonGamesPlayed: {profile.Snapshot.TotalRankedSeasonGamesPlayed}");

                //Console.WriteLine($"TerranWins: {profile.Career.TerranWins}, ZergWins: {profile.Career.ZergWins}, ProtossWins: {profile.Career.ProtossWins}, " +
                //                    $"Best1v1Finish: {profile.Career.Best1v1Finish.TimesAchieved}, BestTeamFinish: {profile.Career.BestTeamFinish.TimesAchieved},");

                //foreach (EarnedAchievement EA in profile.EarnedAchievements)
                //{
                //    Console.WriteLine($"AchievementId: {EA.AchievementId}");
                //}

                MetaData metaData = await sc2Api.GetMetaDataAsync(2, 1, sc2ID);
                Console.WriteLine($"Name: {metaData.Name}, ProfileUrl: {metaData.ProfileUrl}, AvatarUrl: {metaData.AvatarUrl},ProfileId: {metaData.ProfileId}, " +
                                     $"RegionId: {metaData.RegionId}, RealmId: {metaData.RealmId}");

            }).GetAwaiter().GetResult();


            Console.Read();
        }
    }
}
