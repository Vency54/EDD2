using System.Runtime.InteropServices;

namespace Projeto_Cursos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha;
            bool sair = false;
            Escola minhaEscola = new Escola();

            while (sair == false)
            {
                Console.WriteLine("Bem-vindo ao sistema de gerenciamento de Cursos!");
                Console.WriteLine();
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso");
                Console.WriteLine("3. Remover curso");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina");
                Console.WriteLine("6. Remover disciplina do curso");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno");
                Console.WriteLine();

                Console.WriteLine("Escolha uma opção:");

                switch (escolha = int.Parse(Console.ReadLine()))
                {
                    case 0:
                        {
                            Console.WriteLine("Saindo do sistema...");
                            sair = true;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("Digite o ID do curso: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite a descrição do curso: ");
                            string descricao = Console.ReadLine();

                            Curso novoCurso = new Curso(id, descricao);

                            if (minhaEscola.adicionarCurso(novoCurso))
                            {
                                Console.WriteLine("Curso adicionado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível adicionar o curso.");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Digite o ID do curso: ");
                            int id = int.Parse(Console.ReadLine());

                            Curso procurar = new Curso(id, " ");
                            Curso cursoEncontrado = minhaEscola.pesquisarCurso(procurar);

                            Console.WriteLine();
                            if (cursoEncontrado != null)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Curso encontrado:");
                                Console.WriteLine($"Id: {cursoEncontrado.Id}");
                                Console.WriteLine($"Descrição: {cursoEncontrado.Descricao}");
                                Console.WriteLine();
                                Console.WriteLine("Disciplinas:");

                                bool possuiDisciplina = false;
                                foreach (Disciplina disciplina in cursoEncontrado.Disciplinas)
                                {
                                    if(disciplina != null)
                                    {
                                        possuiDisciplina = true;

                                        Console.WriteLine($"Id: {disciplina.Id} - {disciplina.Descricao}");
                                    }
                                }
                                if (!possuiDisciplina)
                                {
                                    Console.WriteLine("Nenhuma disciplina cadastrada.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Curso não encontrado.");
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Digite o ID do Curso: ");
                            int id = int.Parse(Console.ReadLine());

                            Curso procurar = new Curso(id, " ");
                            Curso cursoEncontrado = minhaEscola.pesquisarCurso(procurar);
                            if (cursoEncontrado == null)
                            {
                                Console.WriteLine("Curso não encontrado.");
                            }
                            else if (cursoEncontrado.possuiDisciplinas())
                            {
                                Console.WriteLine("Não é possível remover o curso, pois ele possui disciplinas.");
                            }
                            else {
                                if (minhaEscola.removerCurso(procurar))
                                {
                                    Console.WriteLine("Curso excluído com sucesso!");
                                }

                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Digite o ID do Curso: ");
                            int id = int.Parse(Console.ReadLine());

                            Curso procurar = new Curso(id, " ");
                            Curso cursoEncontrado = minhaEscola.pesquisarCurso(procurar);

                            if (cursoEncontrado != null)
                            {
                                Console.WriteLine("Digite o Id da disciplina: ");
                                int idDisc = int.Parse(Console.ReadLine());

                                Console.WriteLine("Digite a descrição da disciplina: ");
                                string descricao = Console.ReadLine();

                                Disciplina novaDisciplina = new Disciplina(idDisc, descricao);
                                if (cursoEncontrado.adicionarDisciplina(novaDisciplina))
                                {
                                    Console.WriteLine("Disciplina adicionada!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível adicionar a Disciplina.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Curso não encontrado.");
                            }
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Digite o ID da disciplina: ");
                            int id = int.Parse(Console.ReadLine());

                            Disciplina procurar = new Disciplina(id, " ");

                            bool achou = false;

                            foreach (Curso c in minhaEscola.Cursos)
                            {
                                if (c != null)
                                {
                                    Disciplina disciplinaEncontrada = c.pesquisarDisciplina(procurar);

                                    if (disciplinaEncontrada != null)
                                    {
                                        achou = true;
                                        Console.WriteLine();
                                        Console.WriteLine("Disciplina encontrada:");
                                        Console.WriteLine($"Id: {disciplinaEncontrada.Id}");
                                        Console.WriteLine($"Descrição: {disciplinaEncontrada.Descricao}");
                                        Console.WriteLine();
                                        Console.WriteLine("Alunos:");
                                        bool possuiAlunos = false;
                                        
                                        foreach (Aluno aluno in disciplinaEncontrada.Alunos)
                                        {
                                            if(aluno != null)
                                            {
                                                possuiAlunos = true;
                                                Console.WriteLine($"Id: {aluno.Id} - {aluno.Nome}");
                                            }
                                        }
                                        if (!possuiAlunos)
                                        {
                                            Console.WriteLine("Nenhum aluno matriculado.");
                                        }

                                    }
                                }
                            }
                            if (!achou)
                            {
                                Console.WriteLine("Disciplina não encontrada.");
                            }
                        }
                        break;


                    case 6:
                        {
                            Console.WriteLine("Digite o ID do curso:");
                            int idCurso = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite o ID da disciplina:");
                            int idDisc = int.Parse(Console.ReadLine());

                            Curso cursoEncontrado = null;

                            foreach (Curso curso in minhaEscola.Cursos)
                            {
                                if (curso != null && curso.Id == idCurso)
                                {
                                    cursoEncontrado = curso;
                                    break;
                                }
                            }

                            if (cursoEncontrado == null)
                            {
                                Console.WriteLine("Curso não encontrado.");
                                break;
                            }

                            Disciplina disciplinaProcurar = new Disciplina(idDisc, "");

                            if (cursoEncontrado.removerDisciplina(disciplinaProcurar))
                            {
                                Console.WriteLine("Disciplina removida com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Não foi possível remover a disciplina. " +
                                    "Ela pode não existir ou possuir alunos."
                                );
                            }
                        }
                        break;

                    case 7:
                        {
                            Console.WriteLine("Digite o ID do curso:");
                            int idCurso = int.Parse(Console.ReadLine());

                            Curso cursoProcurar = new Curso(idCurso, "");
                            Curso cursoEncontrado = minhaEscola.pesquisarCurso(cursoProcurar);

                            if (cursoEncontrado == null)
                            {
                                Console.WriteLine("Curso não encontrado.");
                                break;
                            }

                            Console.WriteLine("Digite o ID da disciplina:");
                            int idDisc = int.Parse(Console.ReadLine());

                            Disciplina disciplinaProcurar = new Disciplina(idDisc, "");

                            Disciplina disciplinaEncontrada =
                                cursoEncontrado.pesquisarDisciplina(disciplinaProcurar);

                            if (disciplinaEncontrada == null)
                            {
                                Console.WriteLine("Disciplina não encontrada.");
                                break;
                            }

                            Console.WriteLine("Digite o ID do aluno:");
                            int idAluno = int.Parse(Console.ReadLine());

                            Aluno alunoEncontrado = null;
                            Curso cursoDoAluno = null;

                            foreach (Curso curso in minhaEscola.Cursos)
                            {
                                if (curso != null)
                                {
                                    foreach (Disciplina disciplina in curso.Disciplinas)
                                    {
                                        if (disciplina != null)
                                        {
                                            Aluno aluno = disciplina.pesquisarAluno(idAluno);

                                            if (aluno != null)
                                            {
                                                alunoEncontrado = aluno;
                                                cursoDoAluno = curso;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (alunoEncontrado != null)
                                {
                                    break;
                                }
                            }

                            if (alunoEncontrado != null &&
                                cursoDoAluno != cursoEncontrado)
                            {
                                Console.WriteLine("O aluno já está matriculado em outro curso.");
                                break;
                            }

                            if (alunoEncontrado == null)
                            {
                                Console.WriteLine("Digite o nome do aluno:");
                                string nomeAluno = Console.ReadLine();

                                alunoEncontrado = new Aluno(idAluno, nomeAluno);
                            }

                            if (!alunoEncontrado.podeMatricular(cursoEncontrado))
                            {
                                Console.WriteLine("O aluno já está matriculado em 6 disciplinas.");
                            }
                            else if (disciplinaEncontrada.matricularAluno(alunoEncontrado))
                            {
                                Console.WriteLine("Aluno matriculado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível matricular o aluno.");
                            }
                        }
                            break;
                    case 8:
                        {
                            Console.WriteLine("Digite o ID do Curso: ");
                            int idCurso = int.Parse(Console.ReadLine());

                            Curso cursoProcurar =
                                new Curso(idCurso, " ");

                            Curso cursoEncontrado =
                                minhaEscola.pesquisarCurso(cursoProcurar);

                            if (cursoEncontrado == null)
                            {
                                Console.WriteLine("Curso não encontrado.");
                                break;
                            }

                            Console.WriteLine("Digite o ID da Disciplina: ");
                            int idDisc = int.Parse(Console.ReadLine());

                            Disciplina disciplinaProcurar =
                                new Disciplina(idDisc, " ");

                            Disciplina disciplinaEncontrada =
                                cursoEncontrado.pesquisarDisciplina(
                                    disciplinaProcurar
                                );

                            if (disciplinaEncontrada == null)
                            {
                                Console.WriteLine("Disciplina não encontrada.");
                                break;
                            }

                            Console.WriteLine("Digite o ID do Aluno: ");
                            int idAluno = int.Parse(Console.ReadLine());

                            Aluno aluno =
                                disciplinaEncontrada.pesquisarAluno(idAluno);

                            if (aluno != null)
                            {
                                if (disciplinaEncontrada.desmatricularAluno(aluno))
                                {
                                    Console.WriteLine(
                                        "Aluno removido com sucesso!"
                                    );
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "Não foi possível remover o aluno."
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Aluno não encontrado na disciplina."
                                );
                            }
                        }
                            break;
                    case 9:
                        {
                            Console.WriteLine("Digite o ID do aluno:");
                            int idAluno = int.Parse(Console.ReadLine());

                            Aluno alunoEncontrado = null;
                            Curso cursoEncontrado = null;

                            foreach (Curso curso in minhaEscola.Cursos)
                            {
                                if (curso != null)
                                {
                                    foreach (Disciplina disciplina in curso.Disciplinas)
                                    {
                                        if (disciplina != null)
                                        {
                                            Aluno aluno = disciplina.pesquisarAluno(idAluno);

                                            if (aluno != null)
                                            {
                                                alunoEncontrado = aluno;
                                                cursoEncontrado = curso;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (alunoEncontrado != null)
                                {
                                    break;
                                }
                            }

                            if (alunoEncontrado == null)
                            {
                                Console.WriteLine("Aluno não encontrado.");
                                break;
                            }

                            Console.WriteLine();
                            Console.WriteLine("Aluno encontrado:");
                            Console.WriteLine($"Id: {alunoEncontrado.Id}");
                            Console.WriteLine($"Nome: {alunoEncontrado.Nome}");

                            Console.WriteLine();
                            Console.WriteLine("Disciplinas:");

                            bool possuiDisciplinas = false;

                            foreach (Disciplina disciplina in cursoEncontrado.Disciplinas)
                            {
                                if (disciplina != null)
                                {
                                    Aluno aluno = disciplina.pesquisarAluno(idAluno);

                                    if (aluno != null)
                                    {
                                        possuiDisciplinas = true;

                                        Console.WriteLine(
                                            $"Id: {disciplina.Id} - {disciplina.Descricao}"
                                        );
                                    }
                                }
                            }

                            if (!possuiDisciplinas)
                            {
                                Console.WriteLine("Nenhuma disciplina encontrada.");
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}