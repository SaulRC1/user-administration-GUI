using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal_Saul_Rodriguez_Naranjo.utilities
{
    /**
     * Clase que hace de base de datos de
     * los usuarios disponibles de la aplicación.
     * Tan solo disponible en memoria.
     * 
     * Mera simulación de lo que sería una base de datos real.
     */
    class UserRepository
    {
        //Lista de usuarios en el repositorio
        private List<User> usersInsideRepository;

        //El repositorio en si mismo (Seguimos patron Singleton)
        private static UserRepository userRepository = new UserRepository();

        /**
         * Debido a que esta clase seguira el patron Singleton,
         * utilizaremos un constructor privado
         */
        private UserRepository()
        {
            //Instanciamos el lector del fichero de usuarios
            UserCredentialsFileReader userCredentialsFileReader 
                = new UserCredentialsFileReader();

            //Hacemos que lea el fichero y añadimos datos al repositorio
            usersInsideRepository = userCredentialsFileReader.getUsersFromFile();
        }

        public static UserRepository getUserRepository()
        {
            return UserRepository.userRepository;
        }

        /**
         * Comprueba si existe el usuario con esas 
         * credenciales dentro del repositorio
         */
        public Boolean checkValidCredentials(String username, String password)
        {
            Boolean validCredentials = false;

            int i = 0;
            while ( i < this.usersInsideRepository.Count && !validCredentials)
            {
                User user = this.usersInsideRepository.ElementAt(i);

                if(user.getUsername().Equals(username) && 
                    user.getPassword().Equals(password))
                {
                    validCredentials = true;
                }
                else
                {
                    i++;
                }
            }

            return validCredentials;
        }
    }
}
