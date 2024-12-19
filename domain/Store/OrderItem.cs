﻿using Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public  class OrderItem
    {
        private readonly OrderItemDto dto;

        public int ProductId => dto.ProductId;
        public string ProductName
        {
            get;
        }
        public int Count
        {
            get { return dto.Count; }
            set
            {

                dto.Count = value;
            }
        }
        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }
        internal OrderItem(OrderItemDto dto)
        {
            this.dto = dto;
        }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");
        }

        public static class DtoFactory
        {
            public static OrderItemDto Create(OrderDto order, int bookId, decimal price, int count)
            {
                if (order == null)
                    throw new ArgumentNullException(nameof(order));

                ThrowIfInvalidCount(count);

                return new OrderItemDto
                {
                    ProductId = bookId,
                    Price = price,
                    Count = count,
                    Order = order,
                };
            }
        }

        public static class Mapper
        {
            public static OrderItem Map(OrderItemDto dto) => new OrderItem(dto);

            public static OrderItemDto Map(OrderItem domain) => domain.dto;
        }
    }
}

