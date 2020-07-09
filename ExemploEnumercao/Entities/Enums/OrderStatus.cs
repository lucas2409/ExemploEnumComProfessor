namespace ExemploEnumercao.Entities.Enums
{
    enum OrderStatus : int
    {
        PendingPayment = 0, //Pagamento pendente
        Processing = 1, // Processando
        Shipped = 2, // Enviado
        Delivered = 3 // Entregue
    }
}
