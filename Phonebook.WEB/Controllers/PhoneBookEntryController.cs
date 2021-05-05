using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Phonebook.BLL.DTO;
using Phonebook.BLL.Interfaces;
using Phonebook.DAL.Entities;
using Phonebook.WEB.ViewModel;

namespace Phonebook.WEB.Controllers
{
	[ApiController]
	[Route("api/entry")]
	public class PhoneBookEntryController : ControllerBase
	{
		private readonly IPhoneBookEntryService _service;

		public PhoneBookEntryController(IPhoneBookEntryService service)
		{
			_service = service;
		}
		
		[HttpGet]
		[Route("getall")]
		public List<PhoneBookEntry> GetAll()
		{
			return _service.GetAll();
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult GetUser(long id)
		{
			var entry = _service.GetById(id);
			
			return Ok(entry);
		}

		[HttpPut]
		[Route("update")]
		public void Update(PhoneBookEntryViewModel viewModel)
		{
			var updateModel = new PhoneBookEntryDTO()
			{
				Id = viewModel.Id,
				Name = viewModel.Name,
				SecondName = viewModel.SecondName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				Gender = viewModel.Gender,
				Birthday = Convert.ToDateTime(viewModel.Birthday)
			};
			
			_service.Update(updateModel);
		}

		[HttpPost]
		[Route("create")]
		public IActionResult Create(PhoneBookEntryViewModel viewModel)
		{
			var newEntry = new PhoneBookEntryDTO()
			{
				Name = viewModel.Name,
				SecondName = viewModel.SecondName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				Gender = viewModel.Gender,
				Birthday = Convert.ToDateTime(viewModel.Birthday)
			};
			
			_service.Create(newEntry);
			
			return Ok("Запись успешно добавлена");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			_service.RemoveEntry(id);
			return Ok("Запись успешно удалена");
		}
	}
}