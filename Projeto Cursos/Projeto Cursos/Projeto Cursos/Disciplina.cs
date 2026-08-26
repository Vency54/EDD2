using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cursos
{
    internal class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos = new Aluno[15];

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        internal Aluno[] Alunos { get => alunos; }

        public Disciplina(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public bool matricularAluno(Aluno aluno)
        {

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null &&
                    alunos[i].Id == aluno.Id)
                {
                    return false;
                }
            }

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == null)
                {
                    alunos[i] = aluno;
                    return true;
                }
            }

            return false;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null &&
                    alunos[i].Id == aluno.Id)
                {
                    for (int j = i; j < alunos.Length - 1; j++)
                    {
                        alunos[j] = alunos[j + 1];
                    }

                    alunos[alunos.Length - 1] = null;

                    return true;
                }
            }

            return false;
        }

        public Aluno pesquisarAluno(int id)
        {
            for (int i = 0; i < alunos.Length; i++)
            {
                if ((alunos[i] != null && alunos[i].Id == id))
                {
                    return alunos[i];
                }
            }
            return null;
        }
        public bool possuiAlunos()
        {
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
