using HeadsNHandsTestTask.Entities;
Player player = new Player(20, 15, 150, 6, 200);
Monster monster = new Monster(5, 10, 100, 4, 5);
player.GetPlayerInfo();
monster.GetMonsterInfo();
player.Attack(monster);
monster.Attack(player);
player.Attack(monster);
monster.Heal();
monster.Attack(player);
player.Heal();
player.Heal();
player.Heal();
player.Heal();
player.Heal();
player.GetPlayerInfo();
monster.GetMonsterInfo();


