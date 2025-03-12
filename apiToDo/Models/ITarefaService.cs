using apiToDo.DTO;
using System.Collections.Generic;

namespace apiToDo.Services
{
    public interface ITarefaService
    {
        IEnumerable<TarefaDTO> ListarTarefas();
        void InserirTarefa(TarefaDTO tarefa);
        bool DeletarTarefa(int id);
        bool AtualizarTarefa(int id, TarefaDTO tarefa);
        TarefaDTO ObterTarefa(int id);
    }
}