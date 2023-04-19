import random

# Set the size of the maze
size = 36

# Initialize the maze with walls
maze = [["#" for x in range(size)] for y in range(size)]

# Set the center of the maze to the start
start = size // 2
maze[start][start] = "S"

# Set the exit of the maze to the outside
exit = start + 1
maze[exit][size - 1] = "E"

# Set the directions of movement
directions = [(1, 0), (0, 1), (-1, 0), (0, -1)]

# Recursive function to carve the maze
def carve_maze(x, y):
    # Shuffle the directions to move
    random.shuffle(directions)

    # Try to move in each direction
    for dx, dy in directions:
        # Calculate the new position
        nx, ny = x + dx, y + dy

        # Check if the new position is inside the maze
        if nx < 0 or ny < 0 or nx >= size or ny >= size:
            continue

        # Check if the new position is a wall
        if maze[nx][ny] == "#":
            # Carve a path from the current position to the new position
            maze[(x + nx) // 2][(y + ny) // 2] = " "
            maze[nx][ny] = "."

            # Recursively carve the maze from the new position
            carve_maze(nx, ny)

# Carve the maze from the center
carve_maze(start, start)

# Print the maze
for row in maze:
    print(" ".join(row))
