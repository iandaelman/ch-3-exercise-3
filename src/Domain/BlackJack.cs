namespace Domain;

public class BlackJack
    {

    private Deck deck;
    public static bool FaceDown = false;
    public static bool FaceUp = true;


    public GameState GameState { get; private set; }
    public Hand PlayerHand { get; }
    public Hand DealerHand { get; }

    public BlackJack() : this(new Deck())
        {

        }
    public BlackJack(Deck deck)
        {
        this.deck = deck;
        PlayerHand = new Hand();
        DealerHand = new Hand();
        Deal();
        }

    private void Deal()
        {
        AddCardToHand(PlayerHand, FaceUp);
        AddCardToHand(PlayerHand, FaceUp);
        AddCardToHand(DealerHand, FaceUp);
        AddCardToHand(DealerHand, FaceDown);
        AdjustGameState(GameState.PlayerPlays);
        }

    public void PassToDealer()
        {
        DealerHand.TurnAllCardsFaceUp();
        AdjustGameState(GameState.DealerPlays);
        LetDealerFinalize();
        }
    public string GameSummary()
        {
        if (GameState != GameState.GameOver)
            return null;
        if (PlayerHand.Value > 21)
            return "Player burned, dealer wins";
        if (PlayerHand.Value == 21 && PlayerHand.NrOfCards == 2 && DealerHand.Value != 21)
            return "BLACKJACK";
        if (PlayerHand.Value == DealerHand.Value)
            return "Equal, dealer wins";
        if (DealerHand.Value > 21)
            return "Dealer burned, player wins";
        if (DealerHand.Value >= PlayerHand.Value)
            return "Dealer wins";
        return "Player wins";
        }

    public void GivePlayerAnotherCard()
        {
        if (GameState == GameState.PlayerPlays)
            {
            PlayerHand.AddCard(deck.Draw());
            AdjustGameState();
            }
        else
            {
            throw new InvalidOperationException("Not possible to give card to player in this gamestate");
            }
        }
    private void AddCardToHand(Hand hand, bool faceUp)
        {
        BlackJackCard card = deck.Draw();
        if (faceUp)
            card.TurnCard();
        hand.AddCard(card);
        }

    private void AdjustGameState(GameState? gameState = null)
        {
        if (gameState.HasValue)
            {
            GameState = gameState.Value;
            }

        if (GameState == GameState.PlayerPlays && PlayerHand.Value >= 21)
            {
            PassToDealer();
            }

        if (GameState == GameState.DealerPlays && (PlayerHand.Value > 21 || DealerHand.Value >= 21 || DealerHand.Value >= PlayerHand.Value))
            {
            GameState = GameState.GameOver;
            }
        }

    private void LetDealerFinalize()
        {
        while (GameState == GameState.DealerPlays)
            {
            AddCardToHand(DealerHand, FaceUp);
            AdjustGameState();
            }
        }
    }

