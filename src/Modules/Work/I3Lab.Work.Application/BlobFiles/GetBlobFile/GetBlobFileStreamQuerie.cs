﻿using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFile
{
    public class GetBlobFileStreamQuerie : IRequest<Result<BlobFileDto>>
    {
        public Guid BlobFileId { get; set; }

        public GetBlobFileStreamQuerie(Guid blobFileId)
        {
            BlobFileId = blobFileId;
        }

    }
}