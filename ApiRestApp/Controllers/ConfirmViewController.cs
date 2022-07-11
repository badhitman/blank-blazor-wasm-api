////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.AspNetCore.Mvc;
using ServerLib;

namespace ApiRestApp.Controllers
{
    /// <summary>
    /// Подтверждение дейсвтия клиента с помощью временных сылок
    /// </summary>
    [Route("mvc/[controller]")]
    public class ConfirmViewController : Controller
    {
        IUsersConfirmationsService _users_confirmations_repo;
        public ConfirmViewController(IUsersConfirmationsService set_confirmations_repo)
        {
            _users_confirmations_repo = set_confirmations_repo;
        }

        /// <summary>
        /// Проверить/прочитать токен подтверждения действия пользователя.
        /// </summary>
        /// <param name="confirm_id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ConfirmAction(string confirm_id)
        {
            ConfirmationResponseModel? res = await _users_confirmations_repo.GetConfirmationAsync(confirm_id);

            return View("Index", res);
        }

        /// <summary>
        /// Подтверждение дейтсвия пользователя
        /// </summary>
        /// <param name="confirm_id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(string confirm_id)
        {
            ResponseBaseModel? res = await _users_confirmations_repo.ConfirmActionAsync(confirm_id);

            return View("ConfirmAction", res);
        }
    }
}
