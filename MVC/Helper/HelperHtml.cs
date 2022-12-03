using MVC.Helper.Enum;

namespace MVC.Helper
{
    public static class HelperHtml
    {
        public  static string MessageAlert(string message, ErrosEnum erro)
        {
            switch (erro)
            {
                case ErrosEnum.padrao:
                    return $"<div class=\"alert alert-primary\" role=\"alert\">{message}</div>";
                case ErrosEnum.Sucesso:
                    return $"<div class=\"alert alert-success\" role=\"alert\">{message}</div>";

                case ErrosEnum.Erro:
                    return $"<div class=\"alert alert-danger\" role=\"alert\">{message}</div>";
 
                case ErrosEnum.aviso:
                    return $"<div class=\"alert alert-warning\" role=\"alert\">{message}</div>";

   
            }
            return message ;
        }
    }
}
