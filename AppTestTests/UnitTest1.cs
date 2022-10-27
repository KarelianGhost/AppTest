using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using AppTest;

namespace AppTestTests
{
    [TestClass]
    public class GetMapValueTest
    {
        [TestMethod]
        public void GetMapValueFilled()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[1, 2] = 2;

            int result = game.GetMapValue(game.data.map, new MapLocation(1, 2));
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void GetMapValueEmpty()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[1, 2] = 2;

            int result = game.GetMapValue(game.data.map, new MapLocation(1, 1));
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetMapValueOutsideBounds()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[1, 2] = 2;

            int result = game.GetMapValue(game.data.map, new MapLocation(100, 100));
            Assert.AreEqual(-1, result);
        }
    }
    [TestClass]
    public class SetMapValueTest
    {
        [TestMethod]
        public void SetMapValueInsideBounds()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            bool res = game.SetMapValue(game.data.map, new MapLocation(1, 2), 2);

            int result = game.data.map.gridArray[1, 2];
            Assert.AreEqual(2, result);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void SetMapValueOutsideBounds()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            bool res = game.SetMapValue(game.data.map, new MapLocation(100, 100), 2);

            Assert.AreEqual(false, res);
        }
    }
    [TestClass]
    public class GetPathTest
    {
        [TestMethod]
        public void GetPathAny()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[0, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 1] = (int)CellType.wall;

            List<Node> path = game.GetPath(new MapLocation(0, 0), new MapLocation(0, 2), game.data);
            List<MapLocation> result = new List<MapLocation>();
            foreach (Node p in path)
            {
                result.Add(p.pos);
            }
            List<MapLocation> expectedPath = new List<MapLocation>();
            expectedPath.Add(new MapLocation(0, 2));
            expectedPath.Add(new MapLocation(1, 2));
            expectedPath.Add(new MapLocation(2, 2));
            expectedPath.Add(new MapLocation(2, 1));
            expectedPath.Add(new MapLocation(2, 0));
            expectedPath.Add(new MapLocation(1, 0));
            expectedPath.Add(new MapLocation(0, 0));

            bool listsEqual = expectedPath.SequenceEqual(result);
            Assert.AreEqual(listsEqual, true);
        }
        [TestMethod]
        public void GetPathShortest()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 5;
            game.data.width = 5;
            game.data.map = new Map(5, 5);
            game.data.map.gridArray[1, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 2] = (int)CellType.wall;
            game.data.map.gridArray[1, 3] = (int)CellType.wall;
            game.data.map.gridArray[3, 1] = (int)CellType.wall;
            game.data.map.gridArray[3, 2] = (int)CellType.wall;
            game.data.map.gridArray[3, 3] = (int)CellType.wall;

            List<Node> path = game.GetPath(new MapLocation(0, 1), new MapLocation(4, 1), game.data);
            List<MapLocation> result = new List<MapLocation>();
            foreach (Node p in path)
            {
                result.Add(p.pos);
            }
            List<MapLocation> expectedPath = new List<MapLocation>();
            expectedPath.Add(new MapLocation(4, 1));
            expectedPath.Add(new MapLocation(4, 0));
            expectedPath.Add(new MapLocation(3, 0));
            expectedPath.Add(new MapLocation(2, 0));
            expectedPath.Add(new MapLocation(1, 0));
            expectedPath.Add(new MapLocation(0, 0));
            expectedPath.Add(new MapLocation(0, 1));

            bool listsEqual = expectedPath.SequenceEqual(result);
            Assert.AreEqual(listsEqual, true);
        }
    }
    [TestClass]
    public class CalculateShortestDistanceBetweenTest
    {
        [TestMethod]
        public void CalculateShortestDistanceBetween1()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[0, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 1] = (int)CellType.wall;

            int result = game.CalculateShortestDistanceBetween(new MapLocation(0, 0), new MapLocation(0, 2));

            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void CalculateShortestDistanceBetween2()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 5;
            game.data.width = 5;
            game.data.map = new Map(5, 5);
            game.data.map.gridArray[1, 0] = (int)CellType.wall;
            game.data.map.gridArray[1, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 2] = (int)CellType.wall;
            game.data.map.gridArray[1, 3] = (int)CellType.wall;
            game.data.map.gridArray[3, 4] = (int)CellType.wall;
            game.data.map.gridArray[3, 1] = (int)CellType.wall;
            game.data.map.gridArray[3, 2] = (int)CellType.wall;
            game.data.map.gridArray[3, 3] = (int)CellType.wall;

            int result = game.CalculateShortestDistanceBetween(new MapLocation(0, 0), new MapLocation(4, 4));

            Assert.AreEqual(16, result);
        }
    }
    [TestClass]
    public class MovePlayerTest
    {
        [TestMethod]
        public void MovePlayerNone()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerMovementDirection = Direction.none;
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.MovePlayer(game.data.playerMovementDirection, game.data);

            int result = game.data.map.gridArray[1, 1];
            Assert.AreEqual((int)CellType.player, result);
            Assert.AreEqual(new MapLocation(1, 1), game.data.playerPos);
        }
        [TestMethod]
        public void MovePlayerUp()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerMovementDirection = Direction.up;
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.MovePlayer(game.data.playerMovementDirection, game.data);

            int result = game.data.map.gridArray[1, 0];
            Assert.AreEqual((int)CellType.player, result);
            Assert.AreEqual(new MapLocation(1, 0), game.data.playerPos);
        }
        [TestMethod]
        public void MovePlayerDown()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerMovementDirection = Direction.down;
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.MovePlayer(game.data.playerMovementDirection, game.data);

            int result = game.data.map.gridArray[1, 2];
            Assert.AreEqual((int)CellType.player, result);
            Assert.AreEqual(new MapLocation(1, 2), game.data.playerPos);
        }
        [TestMethod]
        public void MovePlayerLeft()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerMovementDirection = Direction.left;
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.MovePlayer(game.data.playerMovementDirection, game.data);

            int result = game.data.map.gridArray[0, 1];
            Assert.AreEqual((int)CellType.player, result);
            Assert.AreEqual(new MapLocation(0, 1), game.data.playerPos);
        }
        [TestMethod]
        public void MovePlayerRight()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerMovementDirection = Direction.right;
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.MovePlayer(game.data.playerMovementDirection, game.data);

            int result = game.data.map.gridArray[2, 1];
            Assert.AreEqual((int)CellType.player, result);
            Assert.AreEqual(new MapLocation(2, 1), game.data.playerPos);
        }
    }
    [TestClass]
    public class ChangePlayerPositionTest
    {
        [TestMethod]
        public void ChangePlayerPositionToEmptyCell()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.data.turnAmount = 1;
            bool res = game.ChangePlayerPosition(new MapLocation(1, 0), game.data);
            int oldPosCell = game.data.map.gridArray[1, 1];
            int newPosCell = game.data.map.gridArray[1, 0];

            Assert.AreEqual((int)CellType.empty, oldPosCell);
            Assert.AreEqual((int)CellType.player, newPosCell);
            Assert.AreEqual(true, res);
            Assert.AreEqual(0, game.data.turnAmount);
        }
        [TestMethod]
        public void ChangePlayerPositionToWallCell()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.data.turnAmount = 1;
            game.data.map.gridArray[1, 0] = (int)CellType.wall;
            bool res = game.ChangePlayerPosition(new MapLocation(1, 0), game.data);
            int oldPosCell = game.data.map.gridArray[1, 1];
            int newPosCell = game.data.map.gridArray[1, 0];

            Assert.AreEqual((int)CellType.player, oldPosCell);
            Assert.AreEqual((int)CellType.wall, newPosCell);
            Assert.AreEqual(false, res);
            Assert.AreEqual(1, game.data.turnAmount);
        }
        [TestMethod]
        public void ChangePlayerPositionFromExitCell()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.data.turnAmount = 1;
            game.data.exitPos = new MapLocation(1, 1);
            bool res = game.ChangePlayerPosition(new MapLocation(1, 0), game.data);
            int oldPosCell = game.data.map.gridArray[1, 1];
            int newPosCell = game.data.map.gridArray[1, 0];

            Assert.AreEqual((int)CellType.exit, oldPosCell);
            Assert.AreEqual((int)CellType.player, newPosCell);
            Assert.AreEqual(true, res);
            Assert.AreEqual(0, game.data.turnAmount);
        }
    }
}