using apiToDo.DTO;
using apiToDo.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<TarefaDTO>> GetTarefas()
        {
            try
            {
                var tarefas = _tarefaService.ListarTarefas();
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro ao listar tarefas: {ex.Message}" });
            }
        }

        /// <summary>
        /// Insere uma nova tarefa
        /// </summary>
        [HttpPost]
        public ActionResult InserirTarefa([FromBody] TarefaDTO request)
        {
            try
            {
                if (request == null)
                    return BadRequest(new { msg = "Dados inválidos" });

                _tarefaService.InserirTarefa(request);
                return CreatedAtAction(nameof(GetTarefas), new { msg = "Tarefa criada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro ao inserir tarefa: {ex.Message}" });
            }
        }

        /// <summary>
        /// Deleta uma tarefa pelo ID
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult DeletarTarefa(int id)
        {
            try
            {
                var sucesso = _tarefaService.DeletarTarefa(id);
                if (!sucesso)
                    return NotFound(new { msg = "Tarefa não encontrada" });

                return NoContent(); // 204 - Sem conteúdo
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro ao deletar tarefa: {ex.Message}" });
            }
        }
    }
}