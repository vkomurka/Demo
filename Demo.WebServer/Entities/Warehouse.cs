﻿using Demo.Entities;

namespace Demo.WebServer.Entities;

public class Warehouse : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
