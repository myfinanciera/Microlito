using MediatR;

namespace Siigo.Microservice.Application.Commands.Bank
{

    /// <summary>
    /// Define request for create a bank
    /// </summary>
    /// <param name="Bank">Param of bank to create</param>
    public readonly record struct CreateBankCommandRequest
        (Domain.Aggregates.Bank.Entities.Bank Bank) : IRequest<CreateBankCommandResponse>;

    /// <summary>
    /// Define response for create a bank
    /// </summary>
    /// <param name="Bank">Response of Bank created</param>
    public readonly record struct CreateBankCommandResponse(Domain.Aggregates.Bank.Entities.Bank Bank);

   
   /// <summary>
   /// Define request for update a bank
   /// </summary>
   /// <param name="Bank">param of bank to update  </param>
    public readonly record struct UpdateBankCommandRequest
        (Domain.Aggregates.Bank.Entities.Bank Bank) : IRequest<UpdateBankCommandResponse>;

    /// <summary>
    /// Define response for bank updated
    /// </summary>
    /// <param name="Bank">Response from bank updated </param>
    public readonly record struct UpdateBankCommandResponse(Domain.Aggregates.Bank.Entities.Bank Bank);
    
}