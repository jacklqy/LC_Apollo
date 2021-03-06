// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/ZhaoxiUser.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Zhaoxi.gRPCDemo.UserServer {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class ZhaoxiUser
  {
    static readonly string __ServiceName = "ZhaoxiUser.ZhaoxiUser";

    static readonly grpc::Marshaller<global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserRequest> __Marshaller_ZhaoxiUser_ZhaoxiUserRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserReply> __Marshaller_ZhaoxiUser_ZhaoxiUserReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserReply.Parser.ParseFrom);

    static readonly grpc::Method<global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserRequest, global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserReply> __Method_FindUser = new grpc::Method<global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserRequest, global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "FindUser",
        __Marshaller_ZhaoxiUser_ZhaoxiUserRequest,
        __Marshaller_ZhaoxiUser_ZhaoxiUserReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ZhaoxiUser</summary>
    [grpc::BindServiceMethod(typeof(ZhaoxiUser), "BindService")]
    public abstract partial class ZhaoxiUserBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserReply> FindUser(global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ZhaoxiUserBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_FindUser, serviceImpl.FindUser).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ZhaoxiUserBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_FindUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserRequest, global::Zhaoxi.gRPCDemo.UserServer.ZhaoxiUserReply>(serviceImpl.FindUser));
    }

  }
}
#endregion
