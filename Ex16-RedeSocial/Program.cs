using System;
using System.Collections.Generic;
using System.Linq;

class RedeSocial
{
    private List<Usuario> usuarios;

    public RedeSocial()
    {
        usuarios = new List<Usuario>();
    }

    public void AdicionarUsuario(Usuario novoUsuario)
    {
        usuarios.Add(novoUsuario);
        Console.WriteLine($"Usuário {novoUsuario.Nome} adicionado à rede social.");
    }

    public void AdicionarAmigo(Usuario usuario, Usuario amigo)
    {
        if (usuarios.Contains(usuario) && usuarios.Contains(amigo))
        {
            usuario.AdicionarAmigo(amigo);
            Console.WriteLine($"{usuario.Nome} adicionou {amigo.Nome} como amigo.");
        }
        else
        {
            Console.WriteLine("Usuário ou amigo não encontrado na rede social.");
        }
    }

    public void PublicarMensagem(Usuario usuario, string mensagem)
    {
        if (usuarios.Contains(usuario))
        {
            usuario.PublicarMensagem(mensagem);
        }
        else
        {
            Console.WriteLine("Usuário não encontrado na rede social.");
        }
    }

    public void ComentarPost(Usuario usuario, Post post, string comentario)
    {
        if (usuarios.Contains(usuario) && post != null)
        {
            post.AdicionarComentario(usuario, comentario);
        }
        else
        {
            Console.WriteLine("Usuário ou post não encontrado na rede social.");
        }
    }

    public Usuario BuscarUsuario(string nome)
    {
        return usuarios.FirstOrDefault(u => u.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }
}

class Usuario
{
    public string Nome { get; }
    private List<Usuario> amigos;
    private List<Post> posts;

    public Usuario(string nome)
    {
        Nome = nome;
        amigos = new List<Usuario>();
        posts = new List<Post>();
    }

    public void AdicionarAmigo(Usuario amigo)
    {
        amigos.Add(amigo);
    }

    public void PublicarMensagem(string mensagem)
    {
        Post novoPost = new Post(this, mensagem);
        posts.Add(novoPost);
        Console.WriteLine($"{Nome} publicou uma mensagem: {mensagem}");
    }

    public List<Post> MostrarTimeline()
    {
        return posts;
    }
}

class Post
{
    public Usuario Autor { get; }
    public string Mensagem { get; }
    public List<Comentario> Comentarios { get; }

    public Post(Usuario autor, string mensagem)
    {
        Autor = autor;
        Mensagem = mensagem;
        Comentarios = new List<Comentario>();
    }

    public void AdicionarComentario(Usuario autor, string texto)
    {
        Comentario novoComentario = new Comentario(autor, texto);
        Comentarios.Add(novoComentario);
        Console.WriteLine($"{autor.Nome} comentou no post de {Autor.Nome}: {texto}");
    }
}

class Comentario
{
    public Usuario Autor { get; }
    public string Texto { get; }

    public Comentario(Usuario autor, string texto)
    {
        Autor = autor;
        Texto = texto;
    }
}

class Program
{
    static void Main()
    {
        RedeSocial minhaRedeSocial = new RedeSocial();

        Console.Write("Digite o nome do usuário 1: ");
        string nomeUsuario1 = Console.ReadLine();
        Usuario usuario1 = new Usuario(nomeUsuario1);
        minhaRedeSocial.AdicionarUsuario(usuario1);

        Console.Write("Digite o nome do usuário 2: ");
        string nomeUsuario2 = Console.ReadLine();
        Usuario usuario2 = new Usuario(nomeUsuario2);
        minhaRedeSocial.AdicionarUsuario(usuario2);

        minhaRedeSocial.AdicionarAmigo(usuario1, usuario2);

        Console.Write($"{nomeUsuario1}, o que você gostaria de publicar? ");
        string mensagemUsuario1 = Console.ReadLine();
        minhaRedeSocial.PublicarMensagem(usuario1, mensagemUsuario1);

        Console.Write($"{nomeUsuario1}, digite o nome do usuário que você quer adicionar como amigo: ");
        string nomeAmigoUsuario1 = Console.ReadLine();
        Usuario amigoUsuario1 = minhaRedeSocial.BuscarUsuario(nomeAmigoUsuario1);

        if (amigoUsuario1 != null)
        {
            minhaRedeSocial.AdicionarAmigo(usuario1, amigoUsuario1);
            Console.WriteLine($"{nomeUsuario1} adicionou {amigoUsuario1.Nome} como amigo.");
        }
        else
        {
            Console.WriteLine($"Usuário '{nomeAmigoUsuario1}' não encontrado.");
        }

        IEnumerable<Post> timelineUsuario1 = usuario1.MostrarTimeline();

        if (timelineUsuario1.Any())
        {
            Post primeiroPostUsuario1 = timelineUsuario1.First();

            Console.Write($"{nomeUsuario2}, o que você gostaria de comentar no post de {nomeUsuario1}? ");
            string comentarioUsuario2 = Console.ReadLine();

            minhaRedeSocial.ComentarPost(usuario2, primeiroPostUsuario1, comentarioUsuario2);
        }
        else
        {
            Console.WriteLine($"{nomeUsuario1} não tem nenhum post na timeline.");
        }

        Console.ReadLine();
    }
}
