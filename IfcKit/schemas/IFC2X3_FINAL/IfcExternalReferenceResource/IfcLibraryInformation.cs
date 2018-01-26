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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("18f6d470-1412-4a7d-b9f4-aac72f975e94")]
	public partial class IfcLibraryInformation :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcLibrarySelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Version;
	
		[DataMember(Order=2)] 
		IfcOrganization _Publisher;
	
		[DataMember(Order=3)] 
		IfcCalendarDate _VersionDate;
	
		[DataMember(Order=4)] 
		[MinLength(1)]
		ISet<IfcLibraryReference> _LibraryReference = new HashSet<IfcLibraryReference>();
	
	
		public IfcLibraryInformation()
		{
		}
	
		public IfcLibraryInformation(IfcLabel __Name, IfcLabel? __Version, IfcOrganization __Publisher, IfcCalendarDate __VersionDate, IfcLibraryReference[] __LibraryReference)
		{
			this._Name = __Name;
			this._Version = __Version;
			this._Publisher = __Publisher;
			this._VersionDate = __VersionDate;
			this._LibraryReference = new HashSet<IfcLibraryReference>(__LibraryReference);
		}
	
		[Description("The name which is used to identify the library.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Identifier for the library version used for reference.")]
		public IfcLabel? Version { get { return this._Version; } set { this._Version = value;} }
	
		[Description("Information of the organization that acts as the library publisher.")]
		public IfcOrganization Publisher { get { return this._Publisher; } set { this._Publisher = value;} }
	
		[Description("Date of the referenced version of the library.")]
		public IfcCalendarDate VersionDate { get { return this._VersionDate; } set { this._VersionDate = value;} }
	
		[Description("Information on the library being referenced.")]
		public ISet<IfcLibraryReference> LibraryReference { get { return this._LibraryReference; } }
	
	
	}
	
}
