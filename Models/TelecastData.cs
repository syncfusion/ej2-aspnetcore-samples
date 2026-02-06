#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace EJ2CoreSampleBrowser.Models
{
    public class TelecastData
    {
        public TelecastData() { }

        public TelecastData(string Channel, string Genre, string Program12AM, string Program1AM, string Program2AM, string Program3AM, string Program4AM, string Program5AM, string Program6AM, string Program7AM, string Program8AM, string Program9AM, string Program10AM, string Program11AM, string Program12PM, string Program1PM, string Program2PM, string Program3PM, string Program4PM, string Program5PM, string Program6PM, string Program7PM, string Program8PM, string Program9PM, string Program10PM, string Program11PM)
        {
            this.Channel = Channel;
            this.Genre = Genre;
            this.Program12AM = Program12AM;
            this.Program1AM = Program1AM;
            this.Program2AM = Program2AM;
            this.Program3AM = Program3AM;
            this.Program4AM = Program4AM;
            this.Program5AM = Program5AM;
            this.Program6AM = Program6AM;
            this.Program7AM = Program7AM;
            this.Program8AM = Program8AM;
            this.Program9AM = Program9AM;
            this.Program10AM = Program10AM;
            this.Program11AM = Program11AM;
            this.Program12PM = Program12PM;
            this.Program1PM = Program1PM;
            this.Program2PM = Program2PM;
            this.Program3PM = Program3PM;
            this.Program4PM = Program4PM;
            this.Program5PM = Program5PM;
            this.Program6PM = Program6PM;
            this.Program7PM = Program7PM;
            this.Program8PM = Program8PM;
            this.Program9PM = Program9PM;
            this.Program10PM = Program10PM;
            this.Program11PM = Program11PM;
        }

        public string Channel { get; set; }
        public string Genre { get; set; }
        public string Program12AM { get; set; }
        public string Program1AM { get; set; }
        public string Program2AM { get; set; }
        public string Program3AM { get; set; }
        public string Program4AM { get; set; }
        public string Program5AM { get; set; }
        public string Program6AM { get; set; }
        public string Program7AM { get; set; }
        public string Program8AM { get; set; }
        public string Program9AM { get; set; }
        public string Program10AM { get; set; }
        public string Program11AM { get; set; }
        public string Program12PM { get; set; }
        public string Program1PM { get; set; }
        public string Program2PM { get; set; }
        public string Program3PM { get; set; }
        public string Program4PM { get; set; }
        public string Program5PM { get; set; }
        public string Program6PM { get; set; }
        public string Program7PM { get; set; }
        public string Program8PM { get; set; }
        public string Program9PM { get; set; }
        public string Program10PM { get; set; }
        public string Program11PM { get; set; }

        public static List<TelecastData> GetAllRecords()
        {
            List<TelecastData> TelecastList = new List<TelecastData>
            {
                new TelecastData("USA News Network", "News", "Late Night News", "Overnight Brief", "Overnight Brief", "World Recap", "Early Report", "Morning Preview", "Morning Dispatch", "Daily Brief", "National Update", "National Update", "Midday Report", "Breaking Stories", "Global Roundup", "Current Affairs", "News Desk", "Afternoon Digest", "City Beat", "Evening News", "Evening News", "World Tonight", "Prime Report", "Nightly Brief", "Late Edition", "News Wrap"),
                new TelecastData("American News Channel", "News", "Midnight Update", "Global Overnight", "Global Overnight", "News Replay", "Dawn Dispatch", "Business Early", "Early Edition", "Business Beat", "National Update", "National Update", "In Focus", "Market Pulse", "News Today", "World Matters", "Regional Review", "Evening Preview", "Local Stories", "Evening News", "Evening News", "Global Insight", "Prime Focus", "Night Desk", "Late News", "Final Report"),
                new TelecastData("Science Frontier TV", "Science", "Tech Rewind", "Cosmic Replay", "Cosmic Replay", "Science Vault", "Tech Bits", "Nature Shorts", "How It’s Built", "Nature Unveiled", "Tech Titans", "Future Innovators", "Unknown Worlds", "Planet Secrets", "Tomorrow’s Tech", "Space Frontiers", "Myth Crackers", "Cosmic Discoveries", "Tech Lab", "Science Now", "Innovate Today", "Future Worlds", "Star Explorers", "Tech Deep Dive", "Science Spotlight", "Night Lab"),
                new TelecastData("Explore America", "Science", "Wild Nights", "Explorer Vault", "Explorer Vault", "Hidden Gems", "Wild Shorts", "Nature Dawn", "Wild Expeditions", "American Wilderness", "Tech Titans", "Future Innovators", "Hidden Histories", "Mega Projects", "Great Minds", "Beyond Earth", "Star Journey", "Unique Planet", "Adventure Now", "Wild America", "Explorer’s Log", "Nature Quest", "Epic Journeys", "Lost Worlds", "Planet Stories", "Night Trek"),
                new TelecastData("Silver Screen Network", "Movies", "Movie", "Movie", "Movie", "Late Classic", "Late Classic", "Early Feature", "Shadow of Truth", "Shadow of Truth", "Shadow of Truth", "Power Play", "Power Play", "Power Play", "Power Play", "City Vigilante", "City Vigilante", "City Vigilante", "Hero Saga", "Hero Saga", "Prime Movie", "Prime Movie", "Blockbuster Night", "Blockbuster Night", "Late Show", "Late Show"),
                new TelecastData("Sports USA", "Sports", "Sports Replay", "Game Highlights", "Game Highlights", "Sports Vault", "Early Recap", "Morning Warmup", "Morning Kickoff", "Football Classics", "Live Game Day", "Live Game Day", "Top Plays", "Sports Talk", "Hoops Highlights", "Game Plan", "Sports Roundup", "NFL Breakdown", "Sports Desk", "Live Coverage", "Game Night", "Prime Sports", "Big Match", "Sports Wrap", "Late Game", "Night Recap"),
                new TelecastData("All Sports Network", "Sports", "Late Highlights", "Sports Classics", "Sports Classics", "Game Rewind", "Early Games", "Sports Warmup", "Morning Kickoff", "Classic Matchups", "Live Game Day", "Live Game Day", "Top Plays", "Sports Talk", "Baseball Recap", "Game Plan", "Sports Roundup", "Soccer Highlights", "Sports Central", "Live Action", "Prime Match", "Sports Night", "Big Game", "Game Recap", "Late Sports", "Final Score"),
                new TelecastData("Kids Fun Zone", "Kids", "Cartoon Rewind", "Late Toons", "Late Toons", "Kid Classics", "Kid Classics", "Early Toons", "Adventure Pals", "Super Heroes", "Super Heroes", "Super Heroes", "Mystery Crew", "Funny Chase", "Cartoon Craze", "Quest Buddies", "Quest Buddies", "Team Turbo", "Fun Factory", "Kid Quest", "Toon Time", "Family Flicks", "Adventure Hour", "Night Toons", "Night Toons", "Sleepy Stories"),
                new TelecastData("Family Playhouse", "Kids", "Late Kid Show", "Moonlit Tales", "Moonlit Tales", "Classic Cartoons", "Classic Cartoons", "Morning Pals", "Little Explorers", "Rescue Pals", "House of Laughs", "House of Laughs", "Mystery Crew", "Magic Wishes", "Teen Spotlight", "Ocean Adventures", "Ocean Adventures", "Rescue Pals", "Family Fun", "Kid Adventures", "Toon Party", "Family Time", "Magic Hour", "Evening Toons", "Evening Toons", "Bedtime Tales"),
                new TelecastData("Magic Youth TV", "Kids", "Midnight Toons", "Starlight Stories", "Starlight Stories", "Toon Vault", "Toon Vault", "Early Adventures", "Mouse Playhouse", "City Kids", "Mystery Town", "Mystery Town", "Mystery Crew", "Witch Cottage", "Swamp Tales", "Stepbrothers", "Stepbrothers", "City Kids", "Youth Quest", "Fun Tales", "Cartoon Club", "Kid Heroes", "Magic Night", "Toon Dreams", "Toon Dreams", "Night Stories"),
                new TelecastData("Wild America TV", "Wildlife", "Night Creatures", "Wild Rewind", "Wild Rewind", "Animal Vault", "Nature Clips", "Wild Dawn", "Nature Guide", "Wild Trails", "Predator Watch", "Predator Watch", "Ocean Titans", "Safari Quest", "Big Beasts", "Night Safari", "Night Safari", "Nature Guide", "Wild Tracks", "Animal Planet", "Safari Nights", "Wild World", "Beast Hunters", "Nature Nights", "Wild Chronicles", "Night Beasts"),
                new TelecastData("Earth Discovery", "Nature", "Planet Replay", "Earth After Dark", "Earth After Dark", "Nature Classics", "Earth Early", "Dawn Planet", "Planet Wonders", "Frozen Lands", "Life on Earth", "Life on Earth", "Blue Seas", "Nature Marvels", "Earth Insights", "Night Safari", "Night Safari", "Planet Wonders", "Eco Quest", "Nature Now", "Planet Pulse", "Earth Stories", "Wild Horizons", "Nature Deep", "Earth Night", "Planet Recap"),
            };
            return TelecastList;
        }
    }
}
