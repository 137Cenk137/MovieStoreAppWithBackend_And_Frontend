using AutoMapper;

namespace WebApi.Common;


public interface IBaseCommand
{
    void Handle();
}