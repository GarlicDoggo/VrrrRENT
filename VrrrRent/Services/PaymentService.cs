using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;
using VrrrRent.Repositories;

namespace VrrrRent.Services
{
    public class PaymentService : BaseService
    {
        public PaymentService(IRepositoryWrapper RepositoryWrapper) : base(RepositoryWrapper)
        {

        }

        public List<Payment> GetPayments()
        {
            return repositoryWrapper.PaymentRepository.FindAll().ToList();
        }

        public List<Payment> GetPaymentsByCondition(Expression<Func<Payment, bool>> expression)
        {
            return repositoryWrapper.PaymentRepository.FindByCondition(expression).ToList();
        }

        public void AddPayment(Payment payment)
        {
            repositoryWrapper.PaymentRepository.Create(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            repositoryWrapper.PaymentRepository.Update(payment);
        }

        public void DeletePayment(Payment payment)
        {
            repositoryWrapper.PaymentRepository.Delete(payment);
        }

    }
}
