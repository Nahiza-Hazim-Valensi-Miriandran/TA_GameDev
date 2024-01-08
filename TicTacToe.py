import random as ran
import TICTACTOE_AI as ai

class TicTacToe:
    def __init__(self):
        self.board  = []

    def create_board(self):
        for i in range(3):
            row = []
            for j in range(3):
                row.append('_')
            self.board.append(row)
    

    def get_random_first_player(self):
        return ran.randint(0,1)

    def fill(self, row, col, player):
        self.board[row][col] = player
    
    def is_win(self, player):
        win = True
        l = len(self.board)
        #Scan Rows
        for i in range(l):
            win = True
            for j in range(l):
                if self.board[i][j] != player:
                    win = False
                    break
            if win:
                return win
        
        #Scan colloumn
        for i in range(l):
            win = True
            for j in range(l):
                if self.board[j][i] != player:
                    win = False
                    break
            if win:
                return win

        #scan diagonals
        win = True
        for i in range(l):
            if self.board[i][i] != player and self.board[i][l-1-i] != player:
                win = False
                break
        if win:
            return win
        return False
    
    def draw(self):
        for row in self.board:
            for item in row:
                if item == '-':
                    return False

        return True

    def show(self):
        for row in self.board:
            for item in row:
                print(item, end = ' ')
            print()

    def swap(self, player):
        return 'X' if player == 'O' else 'O'

    def start(self):
        self.create_board()

        player = 'X' if self.get_random_first_player() == 1 else "O"
        while True:
            print(f"Player {player} turn")

            self.show()
            print()

            # User Input
            while True:
                row, col = list(map(int,input("Enter row and column numbers : ").split()))
                if self.board[row-1][col-1] == '_':
                    break
            print()

            #Fix Spot
            self.fill(row-1,col-1,player)

            # Win or Lose
            if self.is_win(player):
                print(f"Player {player} is win")
                break
            
            # Draw
            self.draw()

            # swap player
            player = self.swap(player)

        # END
        print()
        self.show()

# Compleet
tic_tac_toe = TicTacToe()
tic_tac_toe.start()