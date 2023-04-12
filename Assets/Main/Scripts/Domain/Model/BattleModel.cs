using System;
using System.Collections.Generic;
using Roguelike.Domain.Data;

namespace Roguelike.Domain.Model
{
    public static class BattleModel
    {
        public static void Start(Quest quest, Battle battle)
        {
            battle.Player = new Player()
            {
                HP = 20,
                Deck = new List<Card>() {
                    new Card(),
                    new Card(),
                    new Card(),
                },
                Hand = new List<Card>() {
                    new Card(),
                    new Card(),
                    new Card(),
                },
                Field = new List<Card>() {
                    new Card() {
                        MaxHP = 12,
                        HP = 12,
                    },
                    new Card() {
                        MaxHP = 14,
                        HP = 14,
                    },
                    new Card() {
                        MaxHP = 16,
                        HP = 16,
                    },
                },
            };
            battle.Enemy = new Player()
            {
                HP = 20,
                Deck = new List<Card>() {
                    new Card(),
                    new Card(),
                    new Card(),
                },
                Hand = new List<Card>() {
                    new Card(),
                    new Card(),
                    new Card(),
                },
                Field = new List<Card>() {
                    new Card() {
                        MaxHP = 11,
                        HP = 11,
                    },
                    new Card() {
                        MaxHP = 13,
                        HP = 13,
                    },
                    new Card() {
                        MaxHP = 15,
                        HP = 15,
                    },
                },
            };
            battle.Players = new List<Player>()
            {
                battle.Player,
                battle.Enemy,
            };
        }

        public static void Step(Battle battle, IObserver<Player> onWin, IObserver<Card> onDestroy, IObserver<(Card, int)> onDamage)
        {
            foreach (var player in battle.Players)
            {
                foreach (var card in player.Field)
                {
                    TakeDamage(card, 1, onDestroy, onDamage);
                }
            }
        }

        public static void TakeDamage(Card card, int damage, IObserver<Card> onDestroy, IObserver<(Card, int)> onDamage)
        {
            card.HP -= damage;

            if (card.HP <= 0)
            {
                card.HP = 0;
            }

            onDamage.OnNext((card, damage));

            if (card.HP == 0)
            {
                onDestroy.OnNext(card);
            }
        }
    }
}