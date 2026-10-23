using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

/// <summary>
/// Роли: Администратор, Менеджер, Авторизованный пользователь
/// </summary>
public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
