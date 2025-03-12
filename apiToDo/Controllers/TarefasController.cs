using apiToDo.DTO;
using apiToDo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        /// <summary>
        /// Lista todas as tarefas
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<TarefaDTO>> GetTarefas()
        {
            return Ok(_tarefaService.ListarTarefas());
        }

        /// <summary>
        /// Insere uma nova tarefa
        /// </summary>
        [HttpPost]
        public ActionResult InserirTarefa([FromBody] TarefaDTO request)
        {

            if (string.IsNullOrWhiteSpace(request.DS_TAREFA))
                throw new ArgumentException("A descrição da tarefa é obrigatória.");

            _tarefaService.InserirTarefa(request);
            return CreatedAtAction(nameof(GetTarefas), new { msg = "Tarefa criada com sucesso" });

        }

        /// <summary>
        /// Deleta uma tarefa pelo ID
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult DeletarTarefa(int id)
        {
            var removido = _tarefaService.DeletarTarefa(id);
            if (!removido)
                throw new KeyNotFoundException("Tarefa não encontrada.");
            return NoContent();
        }

        // Método para obter tarefa por ID
        [HttpGet("ObterTarefa/{id}")]
        public ActionResult<TarefaDTO> ObterTarefa(int id)
        {
            var tarefa = _tarefaService.ObterTarefa(id);
            return tarefa == null ? throw new KeyNotFoundException("Tarefa não encontrada.") : (ActionResult<TarefaDTO>)Ok(tarefa);
        }

        // Método para atualizar tarefa
        [HttpPut("AtualizarTarefa/{id}")]
        public ActionResult<List<TarefaDTO>> AtualizarTarefa(int id, [FromBody] TarefaDTO tarefaAtualizada)

        {
            if (string.IsNullOrWhiteSpace(tarefaAtualizada.DS_TAREFA))
                throw new ArgumentException("A descrição da tarefa é obrigatória.");

            var atualizado = _tarefaService.AtualizarTarefa(id, tarefaAtualizada);
            if (!atualizado)
                throw new KeyNotFoundException("Tarefa não encontrada.");

            return NoContent();
        }
    }
}