﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IoTSharp.Data.SqlServer.Migrations
{
    public partial class ModifySomething202111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RuleId",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "FlowOperations");

            migrationBuilder.DropColumn(
                name: "RuleId",
                table: "FlowOperations");

            migrationBuilder.DropColumn(
                name: "RuleId",
                table: "BaseEvents");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlowId",
                table: "Flows",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Flows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateId",
                table: "Flows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Createor",
                table: "Flows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExecutorId",
                table: "Flows",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FlowRuleRuleId",
                table: "Flows",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlowStatus",
                table: "Flows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestStatus",
                table: "Flows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Tester",
                table: "Flows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "TesterDateTime",
                table: "Flows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "RuleId",
                table: "FlowRules",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MountType",
                table: "FlowRules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentRuleId",
                table: "FlowRules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "SubVersion",
                table: "FlowRules",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<Guid>(
                name: "FlowId",
                table: "FlowOperations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperationId",
                table: "FlowOperations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseEventEventId",
                table: "FlowOperations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FlowRuleRuleId",
                table: "FlowOperations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Device",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "BaseEvents",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BizData",
                table: "BaseEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FlowRuleRuleId",
                table: "BaseEvents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeviceRules",
                columns: table => new
                {
                    DeviceRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FlowRuleRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConfigUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRules", x => x.DeviceRuleId);
                    table.ForeignKey(
                        name: "FK_DeviceRules_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceRules_FlowRules_FlowRuleRuleId",
                        column: x => x.FlowRuleRuleId,
                        principalTable: "FlowRules",
                        principalColumn: "RuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RuleTaskExecutors",
                columns: table => new
                {
                    ExecutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultConfig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MataData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutorStatus = table.Column<int>(type: "int", nullable: false),
                    AddDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestStatus = table.Column<int>(type: "int", nullable: false),
                    Tester = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TesterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleTaskExecutors", x => x.ExecutorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flows_ExecutorId",
                table: "Flows",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Flows_FlowRuleRuleId",
                table: "Flows",
                column: "FlowRuleRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowOperations_BaseEventEventId",
                table: "FlowOperations",
                column: "BaseEventEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowOperations_FlowId",
                table: "FlowOperations",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowOperations_FlowRuleRuleId",
                table: "FlowOperations",
                column: "FlowRuleRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEvents_FlowRuleRuleId",
                table: "BaseEvents",
                column: "FlowRuleRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRules_DeviceId",
                table: "DeviceRules",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRules_FlowRuleRuleId",
                table: "DeviceRules",
                column: "FlowRuleRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEvents_FlowRules_FlowRuleRuleId",
                table: "BaseEvents",
                column: "FlowRuleRuleId",
                principalTable: "FlowRules",
                principalColumn: "RuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowOperations_BaseEvents_BaseEventEventId",
                table: "FlowOperations",
                column: "BaseEventEventId",
                principalTable: "BaseEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowOperations_FlowRules_FlowRuleRuleId",
                table: "FlowOperations",
                column: "FlowRuleRuleId",
                principalTable: "FlowRules",
                principalColumn: "RuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowOperations_Flows_FlowId",
                table: "FlowOperations",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "FlowId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flows_FlowRules_FlowRuleRuleId",
                table: "Flows",
                column: "FlowRuleRuleId",
                principalTable: "FlowRules",
                principalColumn: "RuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flows_RuleTaskExecutors_ExecutorId",
                table: "Flows",
                column: "ExecutorId",
                principalTable: "RuleTaskExecutors",
                principalColumn: "ExecutorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEvents_FlowRules_FlowRuleRuleId",
                table: "BaseEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowOperations_BaseEvents_BaseEventEventId",
                table: "FlowOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowOperations_FlowRules_FlowRuleRuleId",
                table: "FlowOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowOperations_Flows_FlowId",
                table: "FlowOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_Flows_FlowRules_FlowRuleRuleId",
                table: "Flows");

            migrationBuilder.DropForeignKey(
                name: "FK_Flows_RuleTaskExecutors_ExecutorId",
                table: "Flows");

            migrationBuilder.DropTable(
                name: "DeviceRules");

            migrationBuilder.DropTable(
                name: "RuleTaskExecutors");

            migrationBuilder.DropIndex(
                name: "IX_Flows_ExecutorId",
                table: "Flows");

            migrationBuilder.DropIndex(
                name: "IX_Flows_FlowRuleRuleId",
                table: "Flows");

            migrationBuilder.DropIndex(
                name: "IX_FlowOperations_BaseEventEventId",
                table: "FlowOperations");

            migrationBuilder.DropIndex(
                name: "IX_FlowOperations_FlowId",
                table: "FlowOperations");

            migrationBuilder.DropIndex(
                name: "IX_FlowOperations_FlowRuleRuleId",
                table: "FlowOperations");

            migrationBuilder.DropIndex(
                name: "IX_BaseEvents_FlowRuleRuleId",
                table: "BaseEvents");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "Createor",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "ExecutorId",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "FlowRuleRuleId",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "FlowStatus",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "TestStatus",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "Tester",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "TesterDateTime",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "MountType",
                table: "FlowRules");

            migrationBuilder.DropColumn(
                name: "ParentRuleId",
                table: "FlowRules");

            migrationBuilder.DropColumn(
                name: "SubVersion",
                table: "FlowRules");

            migrationBuilder.DropColumn(
                name: "BaseEventEventId",
                table: "FlowOperations");

            migrationBuilder.DropColumn(
                name: "FlowRuleRuleId",
                table: "FlowOperations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "BizData",
                table: "BaseEvents");

            migrationBuilder.DropColumn(
                name: "FlowRuleRuleId",
                table: "BaseEvents");

            migrationBuilder.AlterColumn<long>(
                name: "FlowId",
                table: "Flows",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "RuleId",
                table: "Flows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "RuleId",
                table: "FlowRules",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "FlowId",
                table: "FlowOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OperationId",
                table: "FlowOperations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "EventId",
                table: "FlowOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RuleId",
                table: "FlowOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "BaseEvents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "RuleId",
                table: "BaseEvents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
