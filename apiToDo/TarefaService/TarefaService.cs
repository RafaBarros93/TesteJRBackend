using apiToDo.DTO;
using apiToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly List<TarefaDTO> _tarefas = new();

        public IEnumerable<TarefaDTO> ListarTarefas()
        {
            return _tarefas;
        }

        public void InserirTarefa(TarefaDTO tarefa)
        {
            _tarefas.Add(tarefa);
        }

        public bool DeletarTarefa(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.ID_TAREFA == id);
            if (tarefa == null) return false;

            _tarefas.Remove(tarefa);
            return true;
        }
    }
}
