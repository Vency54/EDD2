using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cursos
{
    internal class Curso
    {
        private int id;
        private string descricao;
        private Disciplina[] disciplinas = new Disciplina[12];

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        internal Disciplina[] Disciplinas { get => disciplinas; }

        public Curso(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public bool adicionarDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null &&
                    disciplinas[i].Id == disciplina.Id)
                {
                    return false;
                }
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] == null)
                {
                    disciplinas[i] = disciplina;
                    return true;
                }
            }

            return false;
        }

        public Disciplina pesquisarDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].Id == disciplina.Id)
                {
                    return disciplinas[i];
                }
            }
            return null;
        }


        public bool removerDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {

                if (disciplinas[i] != null &&
            disciplinas[i].Id == disciplina.Id)
                {
                    if (disciplinas[i].possuiAlunos())
                    {
                        return false;
                    }
                    for (int j = i; j < disciplinas.Length - 1; j++)
                    {
                        disciplinas[j] = disciplinas[j + 1];
                    }

                    disciplinas[disciplinas.Length - 1] = null;
                    return true;
                }
            }

            return false;

        }

        public bool possuiDisciplinas()
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
