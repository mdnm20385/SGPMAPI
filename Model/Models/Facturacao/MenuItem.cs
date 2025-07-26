using Model.Models.Gene;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.SJM;

namespace Model.Models.Facturacao
{
    public class Menu
    {
        [Key]
        public string MenuStamp { get; set; }

        public string Route { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }

        // Relacionamento com MenuTag - Label
        public string? LabelStamp { get; set; }
        [ForeignKey("LabelStamp")]
        public MenuTag Label { get; set; }

        // Relacionamento com MenuTag - Badge
        public string? BadgeStamp { get; set; }
        [ForeignKey("BadgeStamp")]
        public MenuTag Badge { get; set; }

        // Relacionamento com MenuPermissions
        public string? MenuPermissionsStamp { get; set; }
        [ForeignKey("MenuPermissionsStamp")]
        public MenuPermissions Permissions { get; set; }

        public ICollection<MenuChildrenItem> Children { get; set; }
        public ICollection<UsuarioMenu> UsuarioMenus { get; set; }
    }

    public class MenuChildrenItem
    {
        [Key]
        public string MenuChildrenItemStamp { get; set; }

        public string Route { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        // Permissões
        public string? MenuPermissionsStamp { get; set; }
        [ForeignKey("MenuPermissionsStamp")]
        public MenuPermissions Permissions { get; set; }

        // Hierarquia de subitens
        public ICollection<MenuChildrenItem> Children { get; set; }

        // Menu pai
        public string ParentMenuStamp { get; set; }
        [ForeignKey("ParentMenuStamp")]
        public Menu ParentMenu { get; set; }

        // Item pai (caso seja subitem de outro item)
        public string? ParentItemStamp { get; set; }
        [ForeignKey("ParentItemStamp")]
        public MenuChildrenItem ParentItem { get; set; }
    }



    public class MenuTag
    {
        [Key]
        public string MenuTagStamp { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
    }

    public class MenuPermissions
    {
        [Key]
        public string MenuPermissionsStamp { get; set; }
        public string Only { get; set; }
        public string Except { get; set; }
    }



    public class Menuusr
    {
        [Key]
        public string Menuusrstamp { get; set; }
        public string Menu { get; set; }
        public string Userstamp { get; set; }
        public bool Activo { get; set; }
    }



    //public class Menu
    //{
    //    [Key]
    //    public string MenuStamp { get; set; }

    //    public string Route { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public string Icon { get; set; }

    //    public MenuTag Label { get; set; }
    //    public MenuTag Badge { get; set; }
    //    public MenuPermissions Permissions { get; set; }

    //    public ICollection<MenuChildrenItem> Children { get; set; }

    //    public ICollection<UsuarioMenu> UsuarioMenus { get; set; }
    //}

    //public class MenuChildrenItem
    //{
    //    [Key]
    //    public string MenuChildrenItemStamp { get; set; }

    //    public string Route { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }

    //    public MenuPermissions Permissions { get; set; }
    //    public ICollection<MenuChildrenItem> Children { get; set; }

    //    public string ParentMenuStamp { get; set; }
    //    [ForeignKey("ParentMenuStamp")]
    //    public Menu ParentMenu { get; set; }

    //    public string ParentItemStamp { get; set; }
    //    [ForeignKey("ParentItemStamp")]
    //    public MenuChildrenItem ParentItem { get; set; }
    //}


    //public class MenuTag
    //{
    //    public string Color { get; set; }
    //    public string Value { get; set; }
    //}

    //public class MenuPermissions
    //{
    //    public string Only { get; set; }
    //    public string Except { get; set; }
    //}
    ////public class MenuTag
    ////{
    ////    [Key]
    ////    public string MenuTagStamp { get; set; }

    ////    public string Color { get; set; }
    ////    public string Value { get; set; }
    ////}

    ////public class MenuPermissions
    ////{
    ////    [Key]
    ////    public string MenuPermissionsStamp { get; set; }

    ////    public string Only { get; set; }
    ////    public string Except { get; set; }
    ////}

    public class MenuComUtilizadoresDTO
    {
        public List<Menu> Menu { get; set; }
        public List<string> UtilizadorStamps { get; set; }
    }
    public class UsuarioMenu
    {
        [Key]
        public Guid UsuarioMenuId { get; set; } // Chave primária

        public string PaStamp { get; set; }
        public Usuario Usuario { get; set; }

        public string MenuStamp { get; set; }
        public Menu Menu { get; set; }

        // Propriedades adicionais
        public DateTime DataAtribuicao { get; set; }
    }

    public class MenuDto
    {
        public string Route { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public ICollection<MenuDto> Children { get; set; }
    }

    public class MenuAssignmentDto
    {
        public string UserId { get; set; }
        public ICollection<MenuDto> Menus { get; set; }
    }

    

    public enum TipoGrupoAcesso
    {
        Admin = 1,
        Supervisor = 2,
        UsuarioGeral = 3
    }

}
