﻿namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;
public interface IEntityBase<T> {
    T Id { get; init; }
}
