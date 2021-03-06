﻿using NotaFiscalNet.Core.Interfaces;
using System.Xml;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa uma Coleção de Duplicatas de Cobrança da Nota Fiscal Eletrônica
    /// </summary>
    public sealed class DuplicataCollection : BaseCollection<Duplicata>, ISerializavel, IModificavel
    {
        /// <summary>
        /// Retorna se existe alguma instancia da classe modificada na coleção
        /// </summary>
        public bool Modificado
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.Modificado)
                        return true;
                }
                return false;
            }
        }

        public void Serializar(XmlWriter writer, INFe nfe)
        {
            foreach (var duplicata in this)
            {
                if (duplicata.Modificado)
                    ((ISerializavel)duplicata).Serializar(writer, nfe);
            }
        }
    }
}