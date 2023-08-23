using EstebanJimenezEFP6App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstebanJimenezEFP6App
{
    public class GlobalObjects
    {
        //definimos las propiedades de codificacion de los json
        //que usaremos en los modelos

        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        public static User MyLocalUser = new User();


    }
}
