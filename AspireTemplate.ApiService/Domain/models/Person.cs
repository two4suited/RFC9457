// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// <auto-generated />

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PersonAPI.Service.Models
{

    public partial class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [TypeSpec.Helpers.JsonConverters.NumericConstraint<int>(MinValue = 0, MaxValue = 150)]
        public int Age { get; set; }


    }
}
