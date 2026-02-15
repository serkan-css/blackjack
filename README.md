🃏 Pro Blackjack 21 Simulation (C#)
A feature-rich, object-oriented Blackjack (21) simulation featuring advanced game logic, a persistent betting system, and an integrated developer debug mode.

🚀 Key Features
Pure OOP Architecture: Built with a modular structure including Card, Deck, Hand, and Player classes for high scalability.

Smart Dealer AI: The robot follows professional casino rules (stands on 17, hits below 17) with realistic delays between actions.

Dynamic Betting System: Players start with a virtual wallet of $1000. Features real-time win/loss calculations and bankruptcy checks.

Blackjack Payouts: Includes a special "Natural 21" (Blackjack) check that rewards the player with a 2:1 bonus payout.

Seamless Rendering: Utilizes a custom-built rendering engine that only updates modified console cells, providing a smooth, flicker-free experience.

Integrated Debug Mode (Hidden): Features a "silent" input listener that allows developers to force specific card values during testing without affecting the UI or user experience.

🛠 Technical Details
Language: C#

Framework: .NET 8.0

Programming Paradigm: Object-Oriented Programming (OOP)

Key Components:

Enums: For clean handling of Card Suits and Values.

LINQ: Efficient card searching and deck shuffling logic.

Asynchronous Input: Non-blocking key listening for hidden command execution.

🎮 How to Play
Place Your Bet: Enter the amount you wish to wager from your balance.

Player Turn: * Press [H] to Hit (draw a card).

Press [S] to Stand (keep your current total).

The Goal: Get as close to 21 as possible without going over.

Payout: Standard wins pay 1:1, while a Blackjack (21 on first two cards) pays 2:1.

📂 Project Structure
Card.cs: Defines the identity and value of individual cards.

Deck.cs: Manages the 52-card collection and randomization logic.

Hand.cs: Handles score calculation and the "Ace" (1 or 11) logic.

Program.cs: The core game engine and user interface controller.

🔧 Installation
Bash
# Clone the repository
git clone https://github.com/yourusername/BlackjackSimulation.git

# Navigate to the project folder
cd BlackjackSimulation

# Run the game
dotnet run
