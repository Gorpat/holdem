module Domain

type CardRank =
    | Ace = 14
    | King = 13
    | Queen = 12
    | Jack = 11
    | Ten = 10
    | Nine = 9
    | Eight = 8
    | Seven = 7
    | Six = 6
    | Five = 5
    | Four = 4
    | Three = 3
    | Two = 2

type CardSuit =
    | Hearts = '\u2665'
    | Diamond = '\u2666'
    | Spade = '\u2660'
    | Club = '\u2663'

type Card = 
    CardRank * CardSuit

let cardRank (card:Card) =
    fst card

let cardSuit (card:Card) =
    snd card

type Deck = 
    Card list

type ShuffledDeck = 
    Card list

type CommunityCards =
    Card list

type HoleCards = 
    Card list

type HandRank =
    | HighCard = 0
    | Pair = 1
    | TwoPair = 2
    | ThreeOfAKind = 3
    | Straight = 4
    | Flush = 5
    | FullHouse = 6
    | Poker = 7
    | StraightFlush = 8
    | RoyalFlush = 9

type Hand = {
    rank: HandRank
    rankValue: CardRank
    kicker: CardRank option
}

type Player = {
    name : string
    position : int
    hand: Hand 
    holeCards: HoleCards
}

type Game = {
    players : Player list
}

type CreateDeck = unit -> Deck

type CreateHand = CommunityCards -> HoleCards -> Hand

type CompareHands = Hand -> Hand -> int

type ShuffleDeck = Deck -> ShuffledDeck

type DealHoleCards = ShuffledDeck -> ShuffledDeck * HoleCards

type DealCommunityCards = ShuffledDeck -> ShuffledDeck * CommunityCards

type EvaluateWinner = Player list -> Player

type State = int

let init () : State =
    0

type Message =
    Noop

let update (msg : Message) (model : State) : State =
    match msg with
    | Noop -> model
