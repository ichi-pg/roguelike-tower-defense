namespace Roguelike.Domain.Data
{
    public class Card
    {
        public int Number;
        public int Cost;
        public int MaxHP;
        public int HP;
        public int ATK;
        public int DEF;
        public int Reach;
        public int Range;
        public int Speed;
        public int Shield;
        public Movement Movement;
        public Element Element;
        public State State;
        public Buff Buff;

        //ゴブリン（スピード）
        //リザードマン（攻撃力）
        //盾オーク（防御力）
        //弓ゴブリン（遠距離）
        //獣術師（属性攻撃）
        //トロール（体力と攻撃力）
        //スケルトン（復活）
        //ガーゴイル（飛行）
        //ドラゴン（飛行と範囲攻撃）

        //物理
        //炎
        //雷
        //氷

        //毒（継続ダメージ）
        //眠り（行動阻害）

        //（バフ）
        //（デバフ）

        //やぱタワーディフェンスが一番分かりやすく面白い、ターン制でもいい
        //見た目での分かりやすさ、成長の実感しやすさ
        //どの武器を選んでも正解であり、組み合わせでより正解であり、体験の質が変わる

        //絵を描いてイメージ膨らませよう
    }
}