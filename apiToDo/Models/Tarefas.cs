using apiToDo.DTO;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        private readonly List<TarefaDTO> _listaTarefas;

        public Tarefas()
        {
            _listaTarefas = new List<TarefaDTO>
            {
                new() { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
                new() { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade da Faculdade" },
                new() { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
            };
        }

        public List<TarefaDTO> ListaTarefas()
        {
            return _listaTarefas;
        }

        public void InserirTarefa(TarefaDTO request)
        {
            if (request != null)
            {
                _listaTarefas.Add(request);
            }
        }

        public bool DeletarTarefa(int idTarefa)
        {
            var tarefa = _listaTarefas.FirstOrDefault(t => t.ID_TAREFA == idTarefa);
            if (tarefa == null)
            {
                return false;
            }

            _listaTarefas.Remove(tarefa);
            return true;
        }
    }
}
