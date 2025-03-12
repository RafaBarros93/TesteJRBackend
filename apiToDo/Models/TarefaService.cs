using apiToDo.DTO;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Services
{
    public class TarefaService : ITarefaService
    {


        // Lista em memória para armazenar as tarefas
        private static List<TarefaDTO> _listaTarefas = new List<TarefaDTO>
        {
            new TarefaDTO { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new TarefaDTO { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade" },
            new TarefaDTO { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };

        public IEnumerable<TarefaDTO> ListarTarefas()
        {
            return _listaTarefas;
        }

        public void InserirTarefa(TarefaDTO tarefa)
        {
            /// Incrementa o ID_TAREFA e adiciona a tarefa na lista
            tarefa.ID_TAREFA = _listaTarefas.Count + 1; // Garantir que o ID seja único e incremental
            _listaTarefas.Add(tarefa);
        }

        public bool DeletarTarefa(int id)
        {
            var tarefa = _listaTarefas.FirstOrDefault(t => t.ID_TAREFA == id);
            if (tarefa == null) return false;

            _listaTarefas.Remove(tarefa);
            return true;
        }

        // Novo método para atualizar a tarefa
        public bool AtualizarTarefa(int id, TarefaDTO tarefaAtualizada)
        {
            var tarefaExistente = _listaTarefas.FirstOrDefault(t => t.ID_TAREFA == id);
            if (tarefaExistente == null)
                return false;

            tarefaExistente.DS_TAREFA = tarefaAtualizada.DS_TAREFA;
            return true;
        }

        // Novo método para obter uma tarefa
        public TarefaDTO ObterTarefa(int id)
        {
            return _listaTarefas.FirstOrDefault(t => t.ID_TAREFA == id);
        }
    }
}

