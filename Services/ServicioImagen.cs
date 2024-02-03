﻿
using Firebase.Auth;
using Firebase.Storage;
using ProyectoLibreria.Models;

namespace ProyectoLibreria.Services
{
    public class ServicioImagen : IServicioImagen
    {
        private readonly LibreriaContext _context;
        public ServicioImagen(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<string> SubirImagen(Stream archivo, string nombre)
        {
            string email = "tecnologershn@gmail.com";
            string clave = "Tecno123";
            string ruta = "peliculasdemo.appspot.com";
            string api_key = "AI";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                ruta,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                    .Child("Fotos_Perfil")
                    .Child(nombre)
                    .PutAsync(archivo, cancellation.Token);

            var downloadURL = await task;
            return downloadURL;
                
        }
    }
}