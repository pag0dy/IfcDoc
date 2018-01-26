// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("5abaa3e9-3b43-4c49-9e66-afe0a3c094d5")]
	public abstract partial class IfcCoordinateOperation
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcCoordinateReferenceSystemSelect _SourceCRS;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcCoordinateReferenceSystem _TargetCRS;
	
	
		public IfcCoordinateOperation()
		{
		}
	
		public IfcCoordinateOperation(IfcCoordinateReferenceSystemSelect __SourceCRS, IfcCoordinateReferenceSystem __TargetCRS)
		{
			this._SourceCRS = __SourceCRS;
			this._TargetCRS = __TargetCRS;
		}
	
		[Description("Source coordinate reference system for the operation.")]
		public IfcCoordinateReferenceSystemSelect SourceCRS { get { return this._SourceCRS; } set { this._SourceCRS = value;} }
	
		[Description("Target coordinate reference system for the operation.")]
		public IfcCoordinateReferenceSystem TargetCRS { get { return this._TargetCRS; } set { this._TargetCRS = value;} }
	
	
	}
	
}
