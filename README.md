[![Quality gate](https://sonarcloud.io/api/project_badges/quality_gate?project=KarelianGhost_AppTest)](https://sonarcloud.io/summary/new_code?id=KarelianGhost_AppTest)
# AppTest
Игра-бродилка, в которой игроку предстоит пройти через процедурно генерируемый лабиринт за определённое число ходов, забрать на своём пути сокровище и добраться до выхода.

## Описание функций программы
### public void GameInit(GameData data)
Данная функция инициализирует состояние игры, заполняя объект данных необходимыми данными для начала.
### public bool SetMapValue(Map map, MapLocation pos, int value)
Данная функция заполняет указанную ячейку карты указанным значением. Возвращает True, если данные были записаны в ячейку и False, если была совершена попытка записать данные за пределы карты.
### public int GetMapValue(Map map, MapLocation pos)
Данная функция получает значение с указанной ячейки карты. Возвращает значение ячейки карты. В случае, если была совершена попытка получить данные за пределами карты возвращает -1.
### public void MovePlayer(Direction dir, GameData data)
Данная функция осуществляет перемещение игрока на основе полученного направления.
### public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Данная функция осуществляет попытку перемещения игрока в указанную ячейку. Возвращает True, если перемещение было совершено и False, если переместиться в ячейку не удалось.
### public void SetExitPosition(MapLocation targetPos, GameData data)
Данная функция устанавливает позицию выхода из лабиринта.
### public void SetRandomTreasurePosition(GameData data)
Данная функция осуществляет попытки установить сокровище в случайную свободную ячейку лабиринта.
### public void CheckTreasure(GameData data)
Данная функция проверяет, находится ли сокровище в той же ячейке, что и игрок.
### public void CheckExit(GameData data)
Данная фукнция проверяет, находится ли выход в той же ячейке, что и игрок.
### public void GenerateMaze(GameData data)
Данная функция осуществляет процедурную генерацию случайного лабиринта алгоритмом Эллера.
### public int CalculateShortestDistanceBetween(MapLocation start, MapLocation target)
Данная функция расчитывает длину кратчайшего пути между двумя точками. Возвращает длину пути в ячейках.
### public void BeginSearch(MapLocation start, MapLocation goal, GameData data)
Данная функция осуществляет необходимую подготовку перед началом поиска пути.
### public void Search(Node thisNode, GameData data)
Данная функция осуществляет одну итерацию поиска кратчайшего пути алгоритмом A*
### public bool isClosed(MapLocation pos, GameData data)
Данная функция проверяет, находится ли указанная ячейка в списке закрытых ячеек поиска пути. Возвращает True, если в списке закрытых есть такая ячейка и False, если такой ячейки нет.
### public bool UpdateMarker(MapLocation pos, float g, float h, float f, Node prt, GameData data)
Данная функция осуществляет обновление данных ячейки из списка открытых. Возвращает True, если данные были обновлены и False, если данные не были обновлены.
### public List\<Node> GetPath(MapLocation start, MapLocation target, GameData data)
Данная функция осуществляет поиск кратчайшего пути алгоритмом A*. Возвращает список вершин пути.


## Аттестационное тестирование

## Модульное тестирование

### Тест GetMapValueFilled(Позитивный):
Описание: Получение значения ячейки карты, если поле было заполнено ранее
Функция: public int GetMapValue(Map map, MapLocation pos)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(1, 2) - ссылка на поле карты(1,2)
Ожидаемый результат: Значение равно ячейке (1,2)

### Тест GetMapValueEmpty(Позитивный):
Описание: Получение значения ячейки карты, если поле не было заполнено ранее
Функция: public int GetMapValue(Map map, MapLocation pos)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(1, 1) - ссылка на поле карты(1,1)
Ожидаемый результат: Значения равно 0

### Тест GetMapValueOutsideBounds(Негативный):
Описание: Получение значения ячейки карты, если поле оказалось за пределами карты
Функция: public int GetMapValue(Map map, MapLocation pos)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(100, 100) - ссылка на поле карты(100,100)
Ожидаемый результат: Значение равно -1

### Тест SetMapValueInsideBounds(Позитивный):
Описание: Установка значения ячейки карты, если поле оказалось в пределах карты
Функция: public bool SetMapValue(Map map, MapLocation pos, int value)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(1, 2) - ссылка на поле карты(1,2)
Ожидаемый результат: Значение в ячейке (1,2) равно 2, функция вернула значение True

### Тест SetMapValueOutsideBounds(Негативный):
Описание: Установка значения ячейки карты, если поле оказалось за пределами карты
Функция: public bool SetMapValue(Map map, MapLocation pos, int value)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(100, 100) - ссылка на поле карты(100,100)
Ожидаемый результат: Функция вернула значение False

### Тест ClosedNodeExists(Позитивный):
Описание:
Функция: public bool isClosed(MapLocation pos, GameData data)
Входные данные:
Ожидаемый результат:

### Тест ClosedNodeNotExists(Негативный):
Описание:
Функция: public bool isClosed(MapLocation pos, GameData data)
Входные данные:
Ожидаемый результат:

## Интеграционное тестирование

### Тест GetPathAny(Позитивный):
Описание: Получение пути до указанной ячейки карты
Функция: public List<Node> GetPath(MapLocation start, MapLocation target, GameData data)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 1) - стартовая позиция на поле карты(0,1), new MapLocation(0, 2) - целевая позиция на поле карты(0,2)
Ожидаемый результат: Возвращённый список узлов совпадает ожидаемому 

### Тест GetPathShortest(Позитивный):
Описание: Получение кратчайшего пути до указанной ячейки карты
Функция: public List<Node> GetPath(MapLocation start, MapLocation target, GameData data)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 1) - стартовая позиция на поле карты(0,1), new MapLocation(4, 1) - целевая позиция на поле карты(4,1)
Ожидаемый результат: Возвращённый список узлов совпадает ожидаемому 

### Тест CalculateShortestDistanceBetween1(Позитивный):
Описание: Получение длины кратчайшего пути между двумя ячейками карты
Функция: public int CalculateShortestDistanceBetween(MapLocation start, MapLocation target)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 0) - стартовая позиция на поле карты(0,0), new MapLocation(0, 2) - целевая позиция на поле карты(0,2)
Ожидаемый результат: Возвращённое значение равно 6

### Тест CalculateShortestDistanceBetween2(Позитивный):
Описание: Получение длины кратчайшего пути между двумя ячейками карты
Функция: public int CalculateShortestDistanceBetween(MapLocation start, MapLocation target)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 0) - стартовая позиция на поле карты(0,0), new MapLocation(4, 4) - целевая позиция на поле карты(4,4)
Ожидаемый результат: Возвращённое значение равно 16

### Тест MovePlayerNone(Позитивный):
Описание:
Функция: public void MovePlayer(Direction dir, GameData data)
Входные данные: game.data.map - карта для проверки, new MapLocation(1, 1) - стартовая позиция игрока на поле карты(1,1), new MapLocation(4, 4) - целевая позиция на поле карты(4,4)
Ожидаемый результат:

### Тест MovePlayerLeft(Позитивный):
Описание:
Функция: public void MovePlayer(Direction dir, GameData data)
Входные данные:
Ожидаемый результат:

### Тест MovePlayerRight(Позитивный):
Описание:
Функция: public void MovePlayer(Direction dir, GameData data)
Входные данные:
Ожидаемый результат:

### Тест MovePlayerUp(Позитивный):
Описание:
Функция: public void MovePlayer(Direction dir, GameData data)
Входные данные:
Ожидаемый результат:

### Тест MovePlayerDown(Позитивный):
Описание:
Функция: public void MovePlayer(Direction dir, GameData data)
Входные данные:
Ожидаемый результат:

### Тест ChangePlayerPositionToEmptyCell(Позитивный):
Описание:
Функция: public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Входные данные:
Ожидаемый результат:

### Тест ChangePlayerPositionToWallCell(Негативный):
Описание:
Функция: public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Входные данные:
Ожидаемый результат:

### Тест ChangePlayerPositionFromExitCell(Позитивный):
Описание:
Функция: public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Входные данные:
Ожидаемый результат:

### Тест SearchIteration(Позитивный):
Описание:
Функция: public void Search(Node thisNode, GameData data)
Входные данные:
Ожидаемый результат:

### Тест CheckTreasurePlacement(Позитивный):
Описание:
Функция: public void SetRandomTreasurePosition(GameData data)
Входные данные:
Ожидаемый результат:


