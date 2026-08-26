using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cursos
{
    internal class Aluno
    {
        private int id;
        private string nome;
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }

        public Aluno(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public bool podeMatricular(Curso curso)
        {
            int contador = 0;   
            foreach (Disciplina disciplina in curso.Disciplinas)
            {
                if (disciplina != null)
                {
                    foreach (Aluno aluno in disciplina.Alunos)
                    {
                        if (aluno != null && aluno.Id == this.Id)
                        {
                            contador ++;
                        }
                    }
                }
            }
            if(contador >= 6)
            {
                return false; 
            }
            return true;

        }


    }
}

