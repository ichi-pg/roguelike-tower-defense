using System.Collections.Generic;
using Roguelike.Domain.Data;

namespace Roguelike.Domain.Model
{
    public static class QuestModel
    {
        public static void Start(Quest quest)
        {
            quest.Deck = new List<Card>() {
                new Card(),
                new Card(),
                new Card(),
            };
            quest.Rooms = new List<Room>()
            {
                new Room(),
                new Room(),
                new Room(),
            };
        }

        public static void Step(SaveData saveData, Quest quest, Room room)
        {
            quest.Room = room;
            saveData.Quest = quest;
        }

        public static void Finish(SaveData saveData)
        {
            saveData.Quest = null;
        }

        public static void EarnCard(Quest quest, Card newCard)
        {
            foreach (var card in quest.Deck)
            {
                if (card.Number == newCard.Number)
                {
                    card.ATK++;
                    return;
                }
            }
            if (quest.Deck.Count >= quest.Deck.Capacity)
            {
                return;
            }
            quest.Deck.Add(newCard);
        }
    }
}