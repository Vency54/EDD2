using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cursos
{
    internal class Escola
    {
        private Curso[] cursos = new Curso[5];

        internal Curso[] Cursos { get => cursos; }


        public bool adicionarCurso(Curso curso)
        {

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null &&
                    cursos[i].Id == curso.Id)
                {
                    return false;
                }
            }

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] == null)
                {
                    cursos[i] = curso;
                    return true;
                }
            }

            return false;
        }

        public Curso pesquisarCurso(Curso curso)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null && cursos[i].Id == curso.Id)
                {
                    return cursos[i];
                }
            }
            return null;
        }


        public bool removerCurso(Curso curso)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null &&
                    cursos[i].Id == curso.Id)
                {
                    if (cursos[i].possuiDisciplinas())
                    {
                        return false;
                    }

                    for (int j = i; j < cursos.Length - 1; j++)
                    {
                        cursos[j] = cursos[j + 1];
                    }

                    cursos[cursos.Length - 1] = null;

                    return true;
                }
            }

            return false;

        }
    }
}
