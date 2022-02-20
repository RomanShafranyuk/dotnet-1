﻿using System.Collections.Generic;

namespace Binary_operations
{
    public interface IOperationRepository
    {
        void AddOperation(int index, Operation operation);
        void PrintCollection();
        public int Count();
        void RemoveCollection();
        void RemoveOperation(int index);
        void MinElement();
        public bool CompareOperations(int lhs_index, int rhs_index);
        public List<Operation> GetOperations();
    }
}