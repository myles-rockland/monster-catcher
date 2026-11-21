extends Node

const character_view_directions = {
	Vector2i.DOWN: 0, 
	Vector2i.LEFT: 1, 
	Vector2i.RIGHT: 2, 
	Vector2i.UP: 3,
	Vector2i.ZERO: 0,
	Vector2i(1,1) : 2, # down right
	Vector2i(1,-1) : 2, # up right
	Vector2i(-1,1) : 1, # down left
	Vector2i(-1,-1) : 1, # up left
		}
const LEVEL_PATHS = {}
