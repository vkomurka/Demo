﻿using Demo.DAL;

namespace Demo.WebServer.Entities;

public class Uom : IEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; }
}

