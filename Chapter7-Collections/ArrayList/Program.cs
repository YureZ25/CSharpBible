﻿using ArrayList;

var parent = new Person("Дмитрий", "Никитин");
parent.AddChild("Юрий", "Никитин");
parent.AddChild("Леонид", "Никитин");
parent.AddChild("Владимир", "Никитин");

Console.WriteLine($"Дети родителя {parent}:");
for(int i = 0; i < parent.ChildrenCount; i++)
{
    Console.WriteLine(parent[i]);
}