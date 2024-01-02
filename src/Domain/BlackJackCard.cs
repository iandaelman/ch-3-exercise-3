namespace Domain
    {
    public class BlackJackCard : Card
        {
        public bool FaceUp { get; set; }
        public int Value { get; }
        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue)
            {
            FaceUp = false;
            }

        public void TurnCard()
            {
            FaceUp = !FaceUp;
            }
        }
    }
