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

## Интеграционное тестирование
