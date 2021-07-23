// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/StudyRecord.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Zhaoxi.gRPCDemo.RecordServer {

  /// <summary>Holder for reflection information generated from Protos/StudyRecord.proto</summary>
  public static partial class StudyRecordReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/StudyRecord.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static StudyRecordReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhQcm90b3MvU3R1ZHlSZWNvcmQucHJvdG8SC1N0dWR5UmVjb3JkIh4KEEdl",
            "dFJlY29yZFJlcXVlc3QSCgoCSWQYASABKAUiqAEKEFN0dWR5UmVjb3JkUmVw",
            "bHkSTAoUU3R1ZHlSZWNvcmRNb2RlbExpc3QYASADKAsyLi5TdHVkeVJlY29y",
            "ZC5TdHVkeVJlY29yZFJlcGx5LlN0dWR5UmVjb3JkTW9kZWwaRgoQU3R1ZHlS",
            "ZWNvcmRNb2RlbBIKCgJJZBgBIAEoBRIRCglTdHVkZW50SWQYAiABKAUSEwoL",
            "RGVzY3JpcHRpb24YAyABKAkyXAoLU3R1ZHlSZWNvcmQSTQoNR2V0UmVjb3Jk",
            "TGlzdBIdLlN0dWR5UmVjb3JkLkdldFJlY29yZFJlcXVlc3QaHS5TdHVkeVJl",
            "Y29yZC5TdHVkeVJlY29yZFJlcGx5Qh+qAhxaaGFveGkuZ1JQQ0RlbW8uUmVj",
            "b3JkU2VydmVyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Zhaoxi.gRPCDemo.RecordServer.GetRecordRequest), global::Zhaoxi.gRPCDemo.RecordServer.GetRecordRequest.Parser, new[]{ "Id" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply), global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Parser, new[]{ "StudyRecordModelList" }, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Types.StudyRecordModel), global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Types.StudyRecordModel.Parser, new[]{ "Id", "StudentId", "Description" }, null, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The request message containing the user's name.
  /// </summary>
  public sealed partial class GetRecordRequest : pb::IMessage<GetRecordRequest> {
    private static readonly pb::MessageParser<GetRecordRequest> _parser = new pb::MessageParser<GetRecordRequest>(() => new GetRecordRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetRecordRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetRecordRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetRecordRequest(GetRecordRequest other) : this() {
      id_ = other.id_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetRecordRequest Clone() {
      return new GetRecordRequest(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetRecordRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetRecordRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Id);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetRecordRequest other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Id = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class StudyRecordReply : pb::IMessage<StudyRecordReply> {
    private static readonly pb::MessageParser<StudyRecordReply> _parser = new pb::MessageParser<StudyRecordReply>(() => new StudyRecordReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StudyRecordReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StudyRecordReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StudyRecordReply(StudyRecordReply other) : this() {
      studyRecordModelList_ = other.studyRecordModelList_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StudyRecordReply Clone() {
      return new StudyRecordReply(this);
    }

    /// <summary>Field number for the "StudyRecordModelList" field.</summary>
    public const int StudyRecordModelListFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Types.StudyRecordModel> _repeated_studyRecordModelList_codec
        = pb::FieldCodec.ForMessage(10, global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Types.StudyRecordModel.Parser);
    private readonly pbc::RepeatedField<global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Types.StudyRecordModel> studyRecordModelList_ = new pbc::RepeatedField<global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Types.StudyRecordModel>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Types.StudyRecordModel> StudyRecordModelList {
      get { return studyRecordModelList_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StudyRecordReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StudyRecordReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!studyRecordModelList_.Equals(other.studyRecordModelList_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= studyRecordModelList_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      studyRecordModelList_.WriteTo(output, _repeated_studyRecordModelList_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += studyRecordModelList_.CalculateSize(_repeated_studyRecordModelList_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StudyRecordReply other) {
      if (other == null) {
        return;
      }
      studyRecordModelList_.Add(other.studyRecordModelList_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            studyRecordModelList_.AddEntriesFrom(input, _repeated_studyRecordModelList_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the StudyRecordReply message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public sealed partial class StudyRecordModel : pb::IMessage<StudyRecordModel> {
        private static readonly pb::MessageParser<StudyRecordModel> _parser = new pb::MessageParser<StudyRecordModel>(() => new StudyRecordModel());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<StudyRecordModel> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Zhaoxi.gRPCDemo.RecordServer.StudyRecordReply.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StudyRecordModel() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StudyRecordModel(StudyRecordModel other) : this() {
          id_ = other.id_;
          studentId_ = other.studentId_;
          description_ = other.description_;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StudyRecordModel Clone() {
          return new StudyRecordModel(this);
        }

        /// <summary>Field number for the "Id" field.</summary>
        public const int IdFieldNumber = 1;
        private int id_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Id {
          get { return id_; }
          set {
            id_ = value;
          }
        }

        /// <summary>Field number for the "StudentId" field.</summary>
        public const int StudentIdFieldNumber = 2;
        private int studentId_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int StudentId {
          get { return studentId_; }
          set {
            studentId_ = value;
          }
        }

        /// <summary>Field number for the "Description" field.</summary>
        public const int DescriptionFieldNumber = 3;
        private string description_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Description {
          get { return description_; }
          set {
            description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as StudyRecordModel);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(StudyRecordModel other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (Id != other.Id) return false;
          if (StudentId != other.StudentId) return false;
          if (Description != other.Description) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (Id != 0) hash ^= Id.GetHashCode();
          if (StudentId != 0) hash ^= StudentId.GetHashCode();
          if (Description.Length != 0) hash ^= Description.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (Id != 0) {
            output.WriteRawTag(8);
            output.WriteInt32(Id);
          }
          if (StudentId != 0) {
            output.WriteRawTag(16);
            output.WriteInt32(StudentId);
          }
          if (Description.Length != 0) {
            output.WriteRawTag(26);
            output.WriteString(Description);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (Id != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
          }
          if (StudentId != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(StudentId);
          }
          if (Description.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(StudyRecordModel other) {
          if (other == null) {
            return;
          }
          if (other.Id != 0) {
            Id = other.Id;
          }
          if (other.StudentId != 0) {
            StudentId = other.StudentId;
          }
          if (other.Description.Length != 0) {
            Description = other.Description;
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 8: {
                Id = input.ReadInt32();
                break;
              }
              case 16: {
                StudentId = input.ReadInt32();
                break;
              }
              case 26: {
                Description = input.ReadString();
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code